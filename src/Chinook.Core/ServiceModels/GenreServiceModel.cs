using System.Collections.Generic;

namespace Chinook.Core.ServiceModels
{
    public partial class GenreServiceModel
    {
        public GenreServiceModel()
        {
            Tracks = new HashSet<TrackServiceModel>();
        }

        public long GenreId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TrackServiceModel> Tracks { get; set; }
    }
}
