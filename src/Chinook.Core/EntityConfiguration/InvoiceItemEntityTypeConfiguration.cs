using Chinook.Core.ServiceModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chinook.Core.EntityConfiguration
{
    class InvoiceItemEntityTypeConfiguration : IEntityTypeConfiguration<InvoiceItem>
    {
        public void Configure(EntityTypeBuilder<InvoiceItem> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(e => e.InvoiceLineId);

            entityTypeBuilder.ToTable("invoice_items");

            entityTypeBuilder.HasIndex(e => e.InvoiceId)
                .HasDatabaseName("IFK_InvoiceLineInvoiceId");

            entityTypeBuilder.HasIndex(e => e.TrackId)
                .HasDatabaseName("IFK_InvoiceLineTrackId");

            entityTypeBuilder.Property(e => e.InvoiceLineId)
                .ValueGeneratedNever();

            entityTypeBuilder.Property(e => e.UnitPrice)
                .IsRequired()
                .HasColumnType("NUMERIC(10,2)");

            entityTypeBuilder.HasOne(d => d.Invoice)
                .WithMany(p => p.InvoiceItems)
                .HasForeignKey(d => d.InvoiceId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entityTypeBuilder.HasOne(d => d.Track)
                .WithMany(p => p.InvoiceItems)
                .HasForeignKey(d => d.TrackId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
