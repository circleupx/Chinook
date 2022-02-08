using Chinook.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chinook.Core.EntityConfiguration
{
    class ArtistEntityTypeConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(e => e.ArtistId);

            entityTypeBuilder.ToTable("artists");

            entityTypeBuilder.Property(e => e.ArtistId)
                .ValueGeneratedNever();

            entityTypeBuilder.Property(e => e.Name)
                .HasColumnType("NVARCHAR(120)");
        }
    }
}
