using Chinook.Core.ServiceModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chinook.Core.EntityConfiguration
{
    class GenreEntityTypeConfiguration : IEntityTypeConfiguration<GenreServiceModel>
    {
        public void Configure(EntityTypeBuilder<GenreServiceModel> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(e => e.GenreId);

            entityTypeBuilder.ToTable("genres");

            entityTypeBuilder.Property(e => e.GenreId)
                .ValueGeneratedNever();

            entityTypeBuilder.Property(e => e.Name)
                .HasColumnType("NVARCHAR(120)");
        }
    }
}
