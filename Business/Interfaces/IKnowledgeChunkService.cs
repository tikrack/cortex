using Business.Entities;

namespace Business.Interfaces;

public interface IKnowledgeChunkService
{
    public Task Add(KnowledgeChunk chunk);
}