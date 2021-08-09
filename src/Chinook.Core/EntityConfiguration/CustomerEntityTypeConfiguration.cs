using Chinook.Core.ServiceModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chinook.Core.EntityConfiguration
{
    class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(e => e.CustomerId);

            entityTypeBuilder.ToTable("customers");

            entityTypeBuilder.HasIndex(e => e.SupportRepId)
                .HasDatabaseName("IFK_CustomerSupportRepId");

            entityTypeBuilder.Property(e => e.CustomerId);

            entityTypeBuilder.Property(e => e.Address)
                .HasColumnType("NVARCHAR(70)");

            entityTypeBuilder.Property(e => e.City)
                .HasColumnType("NVARCHAR(40)");

            entityTypeBuilder.Property(e => e.Company)
                .HasColumnType("NVARCHAR(80)");

            entityTypeBuilder.Property(e => e.Country)
                .HasColumnType("NVARCHAR(40)");

            entityTypeBuilder.Property(e => e.Email)
                .IsRequired()
                .HasColumnType("NVARCHAR(60)");

            entityTypeBuilder.Property(e => e.Fax)
                .HasColumnType("NVARCHAR(24)");

            entityTypeBuilder.Property(e => e.FirstName)
                .IsRequired()
                .HasColumnType("NVARCHAR(40)");

            entityTypeBuilder.Property(e => e.LastName)
                .IsRequired()
                .HasColumnType("NVARCHAR(20)");

            entityTypeBuilder.Property(e => e.Phone)
                .HasColumnType("NVARCHAR(24)");

            entityTypeBuilder.Property(e => e.PostalCode)
                .HasColumnType("NVARCHAR(10)");

            entityTypeBuilder.Property(e => e.State)
                .HasColumnType("NVARCHAR(40)");

            entityTypeBuilder.HasOne(d => d.SupportRep)
                .WithMany(p => p.Customers)
                .HasForeignKey(d => d.SupportRepId);
        }
    }
}
