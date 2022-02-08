using Chinook.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chinook.Core.EntityConfiguration
{
    class PlaylistTrackEntityTypeConfiguration : IEntityTypeConfiguration<PlaylistTrack>
    {
        public void Configure(EntityTypeBuilder<PlaylistTrack> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(e => new { e.PlaylistId, e.TrackId });

            entityTypeBuilder.ToTable("playlist_track");

            entityTypeBuilder.HasIndex(e => e.TrackId)
                .HasDatabaseName("IFK_PlaylistTrackTrackId");

            entityTypeBuilder.HasOne(d => d.Playlist)
                .WithMany(p => p.PlaylistTrack)
                .HasForeignKey(d => d.PlaylistId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entityTypeBuilder.HasOne(d => d.Track)
                .WithMany(p => p.PlaylistTrack)
                .HasForeignKey(d => d.TrackId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
