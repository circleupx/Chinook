using Chinook.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chinook.Core.EntityConfiguration
{
    class AlbumsEntityTypeConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(e => e.AlbumId);

            entityTypeBuilder.ToTable("albums");

            entityTypeBuilder.HasIndex(e => e.ArtistId)
                .HasDatabaseName("IFK_AlbumArtistId");

            entityTypeBuilder.Property(e => e.AlbumId)
                .ValueGeneratedNever();

            entityTypeBuilder.Property(e => e.Title)
                .IsRequired()
                .HasColumnType("NVARCHAR(160)");

            entityTypeBuilder.HasOne(d => d.Artist)
                .WithMany(p => p.Albums)
                .HasForeignKey(d => d.ArtistId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
