using Business.Entities;
using Business.Enums;
using Business.Interfaces;
using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Data.Services;

public class KnowledgeService : IKnowledgeService
{
    public async Task<List<Knowledge>> GetAll()
    {
        var db = new CortexDbContext();
        
        return db.Knowledges
            .Include(x => x.Chunks)
            .AsNoTracking()
            .ToList();
    }

    public async Task Add(Knowledge knowledge)
    {
        var db = new CortexDbContext();

        await db.Knowledges.AddAsync(knowledge);
        
        await db.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        var db = new CortexDbContext();

        var knowledge = await db.Knowledges.SingleAsync(x => x.Id == id);

        db.Knowledges.Remove(knowledge);
        
        await db.SaveChangesAsync();
    }

    public async Task UpdateStatus(Guid id, KnowledgeStatus status)
    {
        var db = new CortexDbContext();
        
        await db.Knowledges.ExecuteUpdateAsync(setters =>
        {
            setters.SetProperty(b => b.Status, status);
        });
        
        await db.SaveChangesAsync();
    }
}