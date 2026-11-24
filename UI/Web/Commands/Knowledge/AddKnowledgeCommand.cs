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
            .Select(x => x.ToString() ?? "")
            .ToList();
        
        var client = new OpenAIClient(
            new ApiKeyCredential(settingsDictionary["embedding-model-provider-api-key"]),
            new OpenAIClientOptions()
            {
                Endpoint = new Uri(settingsDictionary["embedding-model-provider-base-url"]) 
            }
        );

        var generator = client.GetEmbeddingClient(settingsDictionary["embedding-model-name"])
            .AsIEmbeddingGenerator(defaultModelDimensions: 1024);
        
        GeneratedEmbeddings<Embedding<float>> embeddings = new();
        
        try
        {
            embeddings = await generator.GenerateAsync(chunks);
        }
        catch (ClientResultException ex)
        {
            var rawResponse = ex.GetRawResponse();
            if (rawResponse != null)
            {
                string errorBody = rawResponse.Content.ToString();
                MessageBox.Show(errorBody); 
            }
            else
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        for (int i = 0; i < chunks.Count; i++)
        {
            var vector = embeddings[i].Vector;
            
            var knowledgeChunk = new KnowledgeChunk()
            {
                Content = chunks[i],
                Embedding = new Vector(vector),
                KnowledgeId =  knowledge.Id
            };
            
            IKnowledgeChunkService knowledgeChunkService = new KnowledgeChunkService();
            await knowledgeChunkService.Add(knowledgeChunk);
        }
        
        webView.PostSuccess(
            type: Name,
            message: "دانش با موفقیت اضافه شد."
        );
    }
}