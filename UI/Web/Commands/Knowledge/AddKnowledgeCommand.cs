using System.ClientModel;
using System.Text.Json;
using Business.Entities;
using Business.Enums;
using Business.Interfaces;
using Data.Services;
using Microsoft.Web.WebView2.WinForms;
using UI.Web.Contract;
using Microsoft.Extensions.AI;
using OpenAI;
using Pgvector;

namespace UI.Web.Commands.Knowledge;

public class AddKnowledgeCommand : IAsyncWebCommand
{
    public string Name => "add-knowledge";
    
    public async Task ExecuteAsync(JsonElement? data, WebView2? webView)
    {
        if (data is not JsonElement element || element.ValueKind == JsonValueKind.Null)
            return;
        
        Business.Entities.Knowledge? knowledge = null;
        
        try
        {
            knowledge = JsonSerializer.Deserialize<Business.Entities.Knowledge>(element, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });
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
        
        ISettingService settingService = new SettingService();

        var settings = await settingService.GetAll();
        var settingsDictionary = settings.ToDictionary(x => x.Key, x => x.Value);

        var chunks = knowledge.Value
            .Chunk(300)
            .Select(x => new string(x))
            .ToList();

        var client = new OpenAIClient(
            new ApiKeyCredential(settingsDictionary["embedding-model-provider-api-key"]),
            new OpenAIClientOptions
            {
                Endpoint = new Uri(settingsDictionary["embedding-model-provider-base-url"])
            }
        );

        var generator = client.GetEmbeddingClient(settingsDictionary["embedding-model-name"])
            .AsIEmbeddingGenerator(defaultModelDimensions: 1024);

        IKnowledgeChunkService knowledgeChunkService = new KnowledgeChunkService();

        try
        {
            const int batchSize = 5;

            for (int i = 0; i < chunks.Count; i += batchSize)
            {
                var batch = chunks
                    .Skip(i)
                    .Take(batchSize)
                    .ToList();

                var embeddings = await generator.GenerateAsync(batch);

                for (int j = 0; j < batch.Count; j++)
                {
                    var knowledgeChunk = new KnowledgeChunk
                    {
                        Content = batch[j],
                        Embedding = new Vector(embeddings[j].Vector),
                        KnowledgeId = knowledge.Id
                    };

                    await knowledgeChunkService.Add(knowledgeChunk);
                }
            }
            
            await knowledgeService.UpdateStatus(
                knowledge.Id,
                KnowledgeStatus.Finished
            );

            webView.PostSuccess(
                type: Name,
                message: "Knowledge added successfully."
            );
        }
        catch (ClientResultException ex)
        {
            var rawResponse = ex.GetRawResponse();

            var errorMessage = rawResponse?.Content.ToString() ?? ex.Message;

            webView.PostError(message: errorMessage);
        }
        catch (Exception ex)
        {
            webView.PostError(message: ex.Message);
        }
    }
}