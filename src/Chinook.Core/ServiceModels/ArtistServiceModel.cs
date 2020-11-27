using System.Collections.Generic;

namespace Chinook.Core.ServiceModels
{
    public partial class ArtistServiceModel
    {
        public ArtistServiceModel()
        {
            Albums = new HashSet<AlbumServiceModel>();
        }

        public long ArtistId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AlbumServiceModel> Albums { get; set; }
    }
}
