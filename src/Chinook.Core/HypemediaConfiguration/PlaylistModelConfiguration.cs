using Chinook.Core.ServiceModels;
using JsonApiFramework.ServiceModel.Configuration;

namespace Chinook.Core.HypemediaConfiguration
{
    class PlaylistModelConfiguration : ResourceTypeBuilder<Playlist>
    {
        public PlaylistModelConfiguration()
        {
            // Exclude EF Core Navigation Properties from Serialization/Deserialization
            this.Attribute(a => a.PlaylistTrack)
                .Ignore();
        }
    }
}
