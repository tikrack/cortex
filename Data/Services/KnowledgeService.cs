using Business.Entities;
using Business.Interfaces;
using Data.Context;

namespace Data.Services;

public class KnowledgeService : IKnowledgeService
{
    public async Task Add(Knowledge knowledge)
    {
        var db = new CortexDbContext();

        await db.Knowledges.AddAsync(knowledge);
        
        await db.SaveChangesAsync();
    }
}