using System.Collections.Generic;

namespace Chinook.Core.ServiceModels
{
    public partial class TrackServiceModel
    {
        public TrackServiceModel()
        {
            InvoiceItems = new HashSet<InvoiceItemServiceModel>();
            PlaylistTrack = new HashSet<PlaylistTrackServiceModel>();
        }

        public long TrackId { get; set; }
        public string Name { get; set; }
        public long? AlbumId { get; set; }
        public long MediaTypeId { get; set; }
        public long? GenreId { get; set; }
        public string Composer { get; set; }
        public long Milliseconds { get; set; }
        public long? Bytes { get; set; }
        public byte[] UnitPrice { get; set; }

        public virtual AlbumServiceModel Album { get; set; }
        public virtual GenreServiceModel Genre { get; set; }
        public virtual MediaTypeServiceModel MediaType { get; set; }
        public virtual ICollection<InvoiceItemServiceModel> InvoiceItems { get; set; }
        public virtual ICollection<PlaylistTrackServiceModel> PlaylistTrack { get; set; }
    }
}
