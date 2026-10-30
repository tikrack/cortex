using Business.Enums;

namespace Business.Entities;

public class Setting
{
    public Guid Id { get; set; }

    public required string Name { get; set; }
    public required string Value { get; set; }

    public string? Description { get; set; }

    public SettingType Type { get; set; }
    public SettingGroup Group { get; set; }
}
