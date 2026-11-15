using System.Text.Json;
using Business.Enums;
using Business.Interfaces;
using Data.Services;
using Microsoft.Web.WebView2.WinForms;
using UI.Web.Contract;

namespace UI.Web.Commands.Knowledge;

public class AddKnowledgeCommand : IAsyncWebCommand
{
    public string Name => "add-knowledge";

    void test(WebView2? webView)
    {
        webView?.CoreWebView2.PostWebMessageAsJson(
            JsonSerializer.Serialize(
                new WebMessageResult() {},
                new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                }
            )
        );
    }
    
    public async Task ExecuteAsync(JsonElement? data, WebView2? webView)
    {
        if (data is not JsonElement element || element.ValueKind == JsonValueKind.Null)
            return;
        
        Business.Entities.Knowledge? knowledge = null;
        
        try
        {
            knowledge = JsonSerializer.Deserialize<Business.Entities.Knowledge>(element);
        }
        catch (Exception e)
        {
            return;
        }

        if (knowledge is null)
        {
            webView.PostError(
                message: "Data is null or empty."
            );
            
            return;
        }

        knowledge.Status = KnowledgeStatus.Pending;
        
        IKnowledgeService knowledgeService = new KnowledgeService();
        
        await knowledgeService.Add(knowledge);
        
        webView.PostSuccess(
            Name,
            message: "Knowledge added successfully."
        );

        var chunks = knowledge.Value
            .Chunk(300)
            .Select(x => x.ToString())
            .ToArray();

        for (int i = 0; i < chunks.Length - 1; i++)
        {
            
        }
    }
}