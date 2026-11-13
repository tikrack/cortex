using Business.Entities;
using Business.Interfaces;
using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Data.Services;

public class SettingService : ISettingService
{
    public async Task<List<Setting>> GetAll()
    {
        var db = new CortexDbContext();

        var settings = await db.Settings
            .OrderBy(x => x.Group)
            .ThenBy(x => x.Name)
            .ToListAsync();

        return settings;
    }

    public async Task UpdateValue(string Key, string? Value)
    {
        var db = new CortexDbContext();

        var s = await db.Settings.SingleAsync(x => x.Key == Key);

        s.Value = Value;

        db.SaveChanges();
    }
}