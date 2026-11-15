using Business.Attributes;

namespace Business.Enums;

public enum KnowledgeStatus
{
    [EnumInfo("Pending")]
    Pending,

    [EnumInfo("Finished")]
    Finished,

    [EnumInfo("Failed")]
    Failed
}
