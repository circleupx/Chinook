using Chinook.Core.ServiceModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chinook.Core.EntityConfiguration
{
    class PlaylistEntityTypeConfiguration : IEntityTypeConfiguration<PlaylistServiceModel>
    {
        public void Configure(EntityTypeBuilder<PlaylistServiceModel> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(e => e.PlaylistId);

            entityTypeBuilder.ToTable("playlists");

            entityTypeBuilder.Property(e => e.PlaylistId)
                .ValueGeneratedNever();

            entityTypeBuilder.Property(e => e.Name)
                .HasColumnType("NVARCHAR(120)");
        }
    }
}
