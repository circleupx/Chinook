﻿using Chinook.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chinook.Core.EntityConfiguration
{
    public class InvoiceItemEntityTypeConfiguration : IEntityTypeConfiguration<InvoiceItem>
    {
        public void Configure(EntityTypeBuilder<InvoiceItem> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(e => e.InvoiceLineId);

            entityTypeBuilder.ToTable("invoice_items");

            entityTypeBuilder.HasIndex(e => e.InvoiceId, "IFK_InvoiceLineInvoiceId");

            entityTypeBuilder.HasIndex(e => e.TrackId, "IFK_InvoiceLineTrackId");

            entityTypeBuilder.Property(e => e.UnitPrice)
                .IsRequired()
                .HasColumnType("NUMERIC(10,2)");

            entityTypeBuilder.HasOne(d => d.Invoice).WithMany(p => p.InvoiceItems)
                .HasForeignKey(d => d.InvoiceId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entityTypeBuilder.HasOne(d => d.Track).WithMany(p => p.InvoiceItems)
                .HasForeignKey(d => d.TrackId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
