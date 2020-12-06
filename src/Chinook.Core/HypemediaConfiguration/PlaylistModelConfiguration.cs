using Chinook.Core.ServiceModels;
using JsonApiFramework.ServiceModel.Configuration;

namespace Chinook.Core.HypemediaConfiguration
{
    class PlaylistModelConfiguration : ResourceTypeBuilder<Playlist>
    {
        public PlaylistModelConfiguration()
        {
            // Ignore ER Core Navigation Properties
            this.Attribute(a => a.PlaylistTrack)
                .Ignore();
        }
    }
}
