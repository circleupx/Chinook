using Chinook.Core.ServiceModels;
using Microsoft.EntityFrameworkCore;

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

        public virtual DbSet<AlbumServiceModel> Albums { get; set; }
        public virtual DbSet<ArtistServiceModel> Artists { get; set; }
        public virtual DbSet<CustomerServiceModel> Customers { get; set; }
        public virtual DbSet<EmployeeServiceModel> Employees { get; set; }
        public virtual DbSet<GenreServiceModel> Genres { get; set; }
        public virtual DbSet<InvoiceItemServiceModel> InvoiceItems { get; set; }
        public virtual DbSet<InvoiceServiceModel> Invoices { get; set; }
        public virtual DbSet<MediaTypeServiceModel> MediaTypes { get; set; }
        public virtual DbSet<PlaylistTrackServiceModel> PlaylistTrack { get; set; }
        public virtual DbSet<PlaylistServiceModel> Playlists { get; set; }
        public virtual DbSet<TrackServiceModel> Tracks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("DataSource=C:\\Users\\Yunier\\Downloads\\chinook\\chinook.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ChinookDbContext).Assembly);
        }
    }
}
