using Business.Entities;
using Business.Enums;
using Business.Interfaces;
using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Data.Services;

public class KnowledgeService : IKnowledgeService
{
    public async Task Add(Knowledge knowledge)
    {
        var db = new CortexDbContext();

        await db.Knowledges.AddAsync(knowledge);
        
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