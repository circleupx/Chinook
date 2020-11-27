using Chinook.Core.ServiceModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chinook.Core.EntityConfiguration
{
    class EmployeeEntityTypeConfiguration : IEntityTypeConfiguration<EmployeeServiceModel>
    {
        public void Configure(EntityTypeBuilder<EmployeeServiceModel> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(e => e.EmployeeId);

            entityTypeBuilder.ToTable("employees");

            entityTypeBuilder.HasIndex(e => e.ReportsTo)
                .HasDatabaseName("IFK_EmployeeReportsTo");

            entityTypeBuilder.Property(e => e.EmployeeId)
                .ValueGeneratedNever();

            entityTypeBuilder.Property(e => e.Address)
                .HasColumnType("NVARCHAR(70)");

            entityTypeBuilder.Property(e => e.BirthDate)
                .HasColumnType("DATETIME");

            entityTypeBuilder.Property(e => e.City)
                .HasColumnType("NVARCHAR(40)");

            entityTypeBuilder.Property(e => e.Country)
                .HasColumnType("NVARCHAR(40)");

            entityTypeBuilder.Property(e => e.Email)
                .HasColumnType("NVARCHAR(60)");

            entityTypeBuilder.Property(e => e.Fax)
                .HasColumnType("NVARCHAR(24)");

            entityTypeBuilder.Property(e => e.FirstName)
                .IsRequired()
                .HasColumnType("NVARCHAR(20)");

            entityTypeBuilder.Property(e => e.HireDate)
                .HasColumnType("DATETIME");

            entityTypeBuilder.Property(e => e.LastName)
                .IsRequired()
                .HasColumnType("NVARCHAR(20)");

            entityTypeBuilder.Property(e => e.Phone)
                .HasColumnType("NVARCHAR(24)");

            entityTypeBuilder.Property(e => e.PostalCode)
                .HasColumnType("NVARCHAR(10)");

            entityTypeBuilder.Property(e => e.State)
                .HasColumnType("NVARCHAR(40)");

            entityTypeBuilder.Property(e => e.Title)
                .HasColumnType("NVARCHAR(30)");

            entityTypeBuilder.HasOne(d => d.ReportsToNavigation)
                .WithMany(p => p.InverseReportsToNavigation)
                .HasForeignKey(d => d.ReportsTo);
        }
    }
}
