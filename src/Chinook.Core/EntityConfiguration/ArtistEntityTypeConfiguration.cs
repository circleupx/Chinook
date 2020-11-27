using Chinook.Core.ServiceModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chinook.Core.EntityConfiguration
{
    class ArtistEntityTypeConfiguration : IEntityTypeConfiguration<ArtistServiceModel>
    {
        public void Configure(EntityTypeBuilder<ArtistServiceModel> entityTypeBuilder)
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
