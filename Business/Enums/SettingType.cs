using Business.Attributes;

namespace Business.Enums;

public enum SettingType
{
    [EnumInfo("String")]
    STRING,

    [EnumInfo("Integer")]
    INTEGER,

    [EnumInfo("Boolean")]
    BOOLEAN
}
