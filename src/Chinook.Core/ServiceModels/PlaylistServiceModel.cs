using System.Collections.Generic;

namespace Chinook.Core.ServiceModels
{
    public partial class PlaylistServiceModel
    {
        public PlaylistServiceModel()
        {
            PlaylistTrack = new HashSet<PlaylistTrackServiceModel>();
        }

        public long PlaylistId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PlaylistTrackServiceModel> PlaylistTrack { get; set; }
    }
}
