using System.Collections.Generic;

namespace Chinook.Core.ServiceModels
{
    public partial class AlbumServiceModel
    {
        public AlbumServiceModel()
        {
            Tracks = new HashSet<TrackServiceModel>();
        }

        public long AlbumId { get; set; }
        public string Title { get; set; }
        public long ArtistId { get; set; }

        public virtual ArtistServiceModel Artist { get; set; }
        public virtual ICollection<TrackServiceModel> Tracks { get; set; }
    }
}
