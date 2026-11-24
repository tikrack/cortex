using Business.Entities;
using Business.Interfaces;
using Data.Context;

namespace Data.Services;

public class KnowledgeChunkService : IKnowledgeChunkService
{
    public async Task Add(KnowledgeChunk chunk)
    {
        var db = new CortexDbContext();
        
        await db.KnowledgeChunks.AddAsync(chunk);
        
        await db.SaveChangesAsync();
    }
}