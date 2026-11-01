using Business.Entities;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Data.Context;

public class CortexDbContext : DbContext
{
    public DbSet<Setting> Settings { get; set; }
    public DbSet<Knowledge> Knowledges { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            "Host=localhost;Port=5432;Database=cortex;Username=postgres;Password=1A2A3b4b"
        );
    }
}