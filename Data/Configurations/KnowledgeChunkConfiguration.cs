using Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations;

public class KnowledgeChunkConfiguration : IEntityTypeConfiguration<KnowledgeChunk>
{
    public void Configure(EntityTypeBuilder<KnowledgeChunk> builder)
    {
        builder.Property(x => x.Content)
            .IsRequired();

        builder.Property(x => x.Embedding)
            .HasColumnType("vector(1024)")
            .IsRequired();

        builder.Property(x => x.KnowledgeId)
            .IsRequired();
    }
}
    