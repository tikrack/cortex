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

        var settings = await db.Settings.ToListAsync();

        return settings;
    }
}