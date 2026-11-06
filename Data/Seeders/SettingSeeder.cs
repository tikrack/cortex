using Business.Entities;
using Business.Enums;
using Microsoft.EntityFrameworkCore;

namespace Data.Seeders;

public class SettingSeeder
{
    public static void Run(DbContext context)
    {
        var settings = context.Set<Setting>();

        if (settings.Any()) return;

        settings.AddRange(
            new Setting
            {
                Name = "Provider Ai Model",
                Value = "",
                Type = SettingType.STRING,
                Group = SettingGroup.AI,
                Description = "Name of your using ai model."
            },
            new Setting
            {
                Name = "Provider Api Key",
                Value = "",
                Type = SettingType.STRING,
                Group = SettingGroup.AI,
                Description = "Api key for using your ai provider models."
            }
        );

        context.SaveChanges();
    }
}
