using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chinook.Core.Models
{
    public class Playlist
    {
        public Playlist()
        {
            PlaylistTrack = new HashSet<PlaylistTrack>();
        }

        public long PlaylistId { get; set; }
        public string Name { get; set; }

        [NotMapped]
        public virtual ICollection<PlaylistTrack> PlaylistTrack { get; set; }
    }
}
