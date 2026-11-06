using Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations;

public class KnowledgeConfiguration : IEntityTypeConfiguration<Knowledge>
{
    public void Configure(EntityTypeBuilder<Knowledge> builder)
    {
        builder.Property(x => x.Name)
            .IsRequired();

        builder.Property(x => x.Value)
            .HasColumnType("text")
            .IsRequired();

        builder.Property(x => x.Type)
            .IsRequired()
            .HasConversion<int>();

        builder.HasMany(x => x.Chunks)
            .WithOne(x => x.Knowledge)
            .HasForeignKey(x => x.KnowledgeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
