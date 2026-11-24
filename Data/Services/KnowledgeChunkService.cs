using Business.Entities;
using Business.Interfaces;
using Data.Context;
using Microsoft.Extensions.AI;

namespace Data.Services;

public class KnowledgeChunkService : IKnowledgeChunkService
{
    public async Task Add(KnowledgeChunk chunk)
    {
        var db = new CortexDbContext();
        
        await db.KnowledgeChunks.AddAsync(chunk);
        
        await db.SaveChangesAsync();
    }

    public Task<List<KnowledgeChunk>> SearchEmbedding(Embedding<float> embedding)
    {
        var db = new CortexDbContext();

        throw new NotImplementedException();
    }
}