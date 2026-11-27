using Business.Entities;
using Microsoft.Extensions.AI;

namespace Business.Interfaces;

public interface IKnowledgeChunkService
{
    public Task Add(KnowledgeChunk chunk);
    
    public Task<List<KnowledgeChunk>> SearchEmbedding(Embedding<float> embedding, int? count = 5);
}