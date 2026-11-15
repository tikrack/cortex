using Business.Entities;
using Business.Enums;

namespace Business.Interfaces;

public interface IKnowledgeService
{
    public Task Add(Knowledge knowledge);
    
    public Task UpdateStatus(Guid id, KnowledgeStatus status);
}