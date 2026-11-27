using System.ClientModel;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using Business.Interfaces;
using Data.Services;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using OpenAI;
using OpenAI.Chat;
using UI.Agent.Tools;

namespace UI;

public partial class Test : Form
{
    public Test()
    {
        InitializeComponent();
    }

    private async void button1_Click(object sender, EventArgs e)
    {
        var log = new StringBuilder();
        var stopwatch = Stopwatch.StartNew();

        void WriteLog(string title, object? content = null)
        {
            log.AppendLine();
            log.AppendLine($"========== {title} | {stopwatch.ElapsedMilliseconds}ms ==========");

            if (content != null)
            {
                log.AppendLine(JsonSerializer.Serialize(
                    content,
                    new JsonSerializerOptions { WriteIndented = true }
                ));
            }
        }

        try
        {
            ISettingService settingService = new SettingService();

            var settings = await settingService.GetAll();
            var settingsDictionary = settings.ToDictionary(x => x.Key, x => x.Value);

            var client = new OpenAIClient(
                new ApiKeyCredential(settingsDictionary["text-model-provider-api-key"]),
                new OpenAIClientOptions
                {
                    Endpoint = new Uri(settingsDictionary["text-model-provider-base-url"])
                }
            );

            var chatClient = client.GetChatClient(settingsDictionary["text-model-name"]);

            var tools = new List<AITool>
            {
                AIFunctionFactory.Create(KnowledgeTools.SearchKnowledge)
            };

            AIAgent agent = chatClient.AsAIAgent(
                name: "CortexAssistant",
                instructions: "You are Cortex. Always provide answers based on your own tools; if the answer to a question is not found within your knowledge, do not rely on general knowledge.",
                tools: tools
            );

            var message = "Hello! What is dot net and asp?";

            WriteLog("USER MESSAGE", message);

            var response = new StringBuilder();

            await foreach (var update in agent.RunStreamingAsync(message))
            {
                WriteLog("AGENT UPDATE", new
                {
                    update.Role,
                    update.AuthorName,
                    update.ResponseId,
                    update.MessageId,
                    update.Text
                });

                foreach (var content in update.Contents)
                {
                    WriteLog($"CONTENT: {content.GetType().Name}", content);

                    if (content is TextContent text)
                    {
                        response.Append(text.Text);
                    }

                    if (content is FunctionCallContent call)
                    {
                        WriteLog("TOOL CALL", new
                        {
                            call.Name,
                            call.CallId,
                            call.Arguments
                        });
                    }

                    if (content is FunctionResultContent result)
                    {
                        WriteLog("TOOL RESULT", new
                        {
                            result.CallId,
                            result.Result
                        });
                    }
                }
            }

            WriteLog("FINAL RESPONSE", response.ToString());
            WriteLog("COMPLETED");

        }
        catch (Exception ex)
        {
            WriteLog("EXCEPTION", ex.ToString());
        }
        finally
        {
            var path = Path.Combine(
                AppContext.BaseDirectory,
                "agent-log.txt"
            );

            await File.WriteAllTextAsync(path, log.ToString(), Encoding.UTF8);

            MessageBox.Show($"Log saved:\n{path}");
        }
    }
}