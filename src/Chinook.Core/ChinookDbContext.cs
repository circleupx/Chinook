using Chinook.Core.ServiceModels;
using Microsoft.EntityFrameworkCore;
using System;

namespace Chinook.Infrastructure.Database
{
    public partial class ChinookDbContext : DbContext
    {
        public ChinookDbContext()
        {

        }

        public ChinookDbContext(DbContextOptions<ChinookDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<InvoiceItem> InvoiceItems { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<MediaType> MediaTypes { get; set; }
        public virtual DbSet<PlaylistTrack> PlaylistTrack { get; set; }
        public virtual DbSet<Playlist> Playlists { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var chinookSQLiteConnectionString = $"DataSource={AppContext.BaseDirectory}chinook.db";
                optionsBuilder.UseSqlite(chinookSQLiteConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ChinookDbContext).Assembly);
        }
    }
}
