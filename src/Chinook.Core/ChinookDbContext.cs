using Chinook.Core.Models;
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

        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<MediaType> MediaTypes { get; set; }
        public DbSet<PlaylistTrack> PlaylistTrack { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Track> Tracks { get; set; }

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
