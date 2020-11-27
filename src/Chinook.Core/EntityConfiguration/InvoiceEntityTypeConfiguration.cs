using Chinook.Core.ServiceModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chinook.Core.EntityConfiguration
{
    class InvoiceEntityTypeConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(e => e.InvoiceId);

            entityTypeBuilder.ToTable("invoices");

            entityTypeBuilder.HasIndex(e => e.CustomerId)
                .HasDatabaseName("IFK_InvoiceCustomerId");

            entityTypeBuilder.Property(e => e.InvoiceId)
                .ValueGeneratedNever();

            entityTypeBuilder.Property(e => e.BillingAddress)
                .HasColumnType("NVARCHAR(70)");

            entityTypeBuilder.Property(e => e.BillingCity)
                .HasColumnType("NVARCHAR(40)");

            entityTypeBuilder.Property(e => e.BillingCountry)
                .HasColumnType("NVARCHAR(40)");

            entityTypeBuilder.Property(e => e.BillingPostalCode)
                .HasColumnType("NVARCHAR(10)");

            entityTypeBuilder.Property(e => e.BillingState)
                .HasColumnType("NVARCHAR(40)");

            entityTypeBuilder.Property(e => e.InvoiceDate)
                .IsRequired()
                .HasColumnType("DATETIME");

            entityTypeBuilder.Property(e => e.Total)
                .IsRequired()
                .HasColumnType("NUMERIC(10,2)");

            entityTypeBuilder.HasOne(d => d.Customer)
                .WithMany(p => p.Invoices)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
