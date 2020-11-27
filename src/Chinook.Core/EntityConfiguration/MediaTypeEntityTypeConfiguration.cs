using Chinook.Core.ServiceModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chinook.Core.EntityConfiguration
{
    class MediaTypeEntityTypeConfiguration : IEntityTypeConfiguration<MediaType>
    {
        public void Configure(EntityTypeBuilder<MediaType> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(e => e.MediaTypeId);

            entityTypeBuilder.ToTable("media_types");

            entityTypeBuilder.Property(e => e.MediaTypeId)
                .ValueGeneratedNever();

            entityTypeBuilder.Property(e => e.Name)
                .HasColumnType("NVARCHAR(120)");
        }
    }
}
