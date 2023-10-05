using Microsoft.EntityFrameworkCore;

namespace Chinook.Core.Models
{
    [Keyless]
    public class PlaylistTrack
    {
        public long PlaylistId { get; set; }
        public long TrackId { get; set; }

        public virtual Playlist Playlist { get; set; }
        public virtual Track Track { get; set; }
    }
}
