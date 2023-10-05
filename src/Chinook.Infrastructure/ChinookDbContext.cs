using Chinook.Core.EntityConfiguration;
using Chinook.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Chinook.Infrastructure
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
            modelBuilder.ApplyConfiguration(new AlbumsEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ArtistEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new GenreEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceItemEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MediaTypeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PlaylistEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PlaylistTrackEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TrackEntityTypeConfiguration());
        }
    }
}
