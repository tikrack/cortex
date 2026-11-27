using Business.Entities;
using Business.Interfaces;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.AI;
using Pgvector.EntityFrameworkCore;

namespace Data.Services;

public class KnowledgeChunkService : IKnowledgeChunkService
{
    public async Task Add(KnowledgeChunk chunk)
    {
        var db = new CortexDbContext();
        
        await db.KnowledgeChunks.AddAsync(chunk);
        
        await db.SaveChangesAsync();
    }

    public async Task<List<KnowledgeChunk>> SearchEmbedding(Embedding<float> embedding, int? count)
    {
        var db = new CortexDbContext();

        var queryVector = new Pgvector.Vector(embedding.Vector.ToArray());

        return await db.KnowledgeChunks
            .OrderBy(x => x.Embedding!.CosineDistance(queryVector))
            .Take(count ?? 5)
            .ToListAsync();
    }
}