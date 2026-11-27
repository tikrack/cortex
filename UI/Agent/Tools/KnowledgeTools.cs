using System.ClientModel;
using System.ComponentModel;
using Business.Interfaces;
using Data.Services;
using Microsoft.Extensions.AI;
using OpenAI;

namespace UI.Agent.Tools;

public class KnowledgeTools
{
    [Description("Based on the input text or term, it searches through all the content within the knowledge bases and returns relevant content and chunks.")]
    public static async Task<object> SearchKnowledge(
        [Description("The text or word being searched for within the content of the entire knowledge base")]
        string phrase
    )
    {
        ISettingService settingService = new SettingService();

        var settings = await settingService.GetAll();
        var settingsDictionary = settings.ToDictionary(x => x.Key, x => x.Value);
        
        var client = new OpenAIClient(
            new ApiKeyCredential(settingsDictionary["embedding-model-provider-api-key"]),
            new OpenAIClientOptions
            {
                Endpoint = new Uri(settingsDictionary["embedding-model-provider-base-url"])
            }
        );

        var generator = client.GetEmbeddingClient(settingsDictionary["embedding-model-name"]);
        
        ClientResult<OpenAI.Embeddings.OpenAIEmbedding> embeddings;

        try
        {
            embeddings = await generator.GenerateEmbeddingAsync(phrase);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Embedding Error");
            throw;
        }

        var embedding = new Embedding<float>(
            embeddings.Value.ToFloats()
        );
        
        IKnowledgeChunkService knowledgeChunkService = new KnowledgeChunkService();

        var chunks = await knowledgeChunkService.SearchEmbedding(embedding, 5);
        
        return new
        {
            Results = chunks.Select(x => new
            {
                x.Content,
                x.KnowledgeId
            }).ToList()
        };
    }
}