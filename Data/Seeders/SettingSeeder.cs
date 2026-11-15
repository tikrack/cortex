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
                Name = "Text Model Provider Base URL",
                Key = "text-model-provider-base-url",
                Value = "",
                Type = SettingType.STRING,
                Group = SettingGroup.AI,
                Description = "Base URL of the text model provider API."
            },
            new Setting
            {
                Name = "Text Model Name",
                Key = "text-model-name",
                Value = "",
                Type = SettingType.STRING,
                Group = SettingGroup.AI,
                Description = "Name or identifier of the text model."
            },
            new Setting
            {
                Name = "Text Model Provider API Key",
                Key = "text-model-provider-api-key",
                Value = "",
                Type = SettingType.STRING,
                Group = SettingGroup.AI,
                Description = "API key used to authenticate with the text model provider."
            },
            new Setting
            {
                Name = "Embedding Model Provider Base URL",
                Key = "embedding-model-provider-base-url",
                Value = "",
                Type = SettingType.STRING,
                Group = SettingGroup.AI,
                Description = "Base URL of the embedding model provider API."
            },
            new Setting
            {
                Name = "Embedding Model Name",
                Key = "embedding-model-name",
                Value = "",
                Type = SettingType.STRING,
                Group = SettingGroup.AI,
                Description = "Name or identifier of the embedding model."
            },
            new Setting
            {
                Name = "Embedding Model Provider API Key",
                Key = "embedding-model-provider-api-key",
                Value = "",
                Type = SettingType.STRING,
                Group = SettingGroup.AI,
                Description = "API key used to authenticate with the embedding model provider."
            }
        );

        context.SaveChanges();
    }
}
