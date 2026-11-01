using Business.Enums;

namespace Business.Entities;

public class Knowledge : BaseEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; }
    public string Value { get; set; }

    public KnowledgeType Type { get; set; }
}
