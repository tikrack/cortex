using Business.Entities;
using Data.Configurations;
using Data.Seeders;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Data.Context;

public class CortexDbContext : DbContext
{
    public DbSet<Setting> Settings => Set<Setting>();
    public DbSet<Knowledge> Knowledges => Set<Knowledge>();
    public DbSet<KnowledgeChunk> KnowledgeChunks => Set<KnowledgeChunk>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseNpgsql(
                "Host=localhost;Port=5432;Database=cortex;Username=postgres;Password=1A2A3b4b",
                o => o.UseVector()
            )
            .UseSeeding((context, _) =>
            {
                SettingSeeder.Run(context);
            });
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasPostgresExtension("vector");

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(CortexDbContext).Assembly
        );

        modelBuilder.ApplyConfiguration(new KnowledgeConfiguration());
        modelBuilder.ApplyConfiguration(new KnowledgeChunkConfiguration());
    }
}