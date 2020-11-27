using System.Collections.Generic;

namespace Chinook.Core.ServiceModels
{
    public partial class MediaTypeServiceModel
    {
        public MediaTypeServiceModel()
        {
            Tracks = new HashSet<TrackServiceModel>();
        }

        public long MediaTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TrackServiceModel> Tracks { get; set; }
    }
}
