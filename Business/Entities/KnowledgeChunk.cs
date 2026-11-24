using System.Text.Json.Serialization;
using Pgvector;

namespace Business.Entities;

public class KnowledgeChunk
{
    public Guid Id { get; set; }

    public Guid KnowledgeId { get; set; }
    [JsonIgnore]
    public Knowledge Knowledge { get; set; }

    public string Content { get; set; }
    public Vector Embedding { get; set; }
}
