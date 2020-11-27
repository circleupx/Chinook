using Chinook.Core.ServiceModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chinook.Core.EntityConfiguration
{
    class TrackEntityTypeConfiguration : IEntityTypeConfiguration<Track>
    {
        public void Configure(EntityTypeBuilder<Track> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(e => e.TrackId);

            entityTypeBuilder.ToTable("tracks");

            entityTypeBuilder.HasIndex(e => e.AlbumId)
                .HasDatabaseName("IFK_TrackAlbumId");

            entityTypeBuilder.HasIndex(e => e.GenreId)
                .HasDatabaseName("IFK_TrackGenreId");

            entityTypeBuilder.HasIndex(e => e.MediaTypeId)
                .HasDatabaseName("IFK_TrackMediaTypeId");

            entityTypeBuilder.Property(e => e.TrackId)
                .ValueGeneratedNever();

            entityTypeBuilder.Property(e => e.Composer)
                .HasColumnType("NVARCHAR(220)");

            entityTypeBuilder.Property(e => e.Name)
                .IsRequired()
                .HasColumnType("NVARCHAR(200)");

            entityTypeBuilder.Property(e => e.UnitPrice)
                .IsRequired()
                .HasColumnType("NUMERIC(10,2)");

            entityTypeBuilder.HasOne(d => d.Album)
                .WithMany(p => p.Tracks)
                .HasForeignKey(d => d.AlbumId);

            entityTypeBuilder.HasOne(d => d.Genre)
                .WithMany(p => p.Tracks)
                .HasForeignKey(d => d.GenreId);

            entityTypeBuilder.HasOne(d => d.MediaType)
                .WithMany(p => p.Tracks)
                .HasForeignKey(d => d.MediaTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
