using System.Collections.Generic;

namespace Chinook.Core.Models
{
    public class Artist
    {
        public Artist()
        {
            Albums = new HashSet<Album>();
        }

        public long ArtistId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}
