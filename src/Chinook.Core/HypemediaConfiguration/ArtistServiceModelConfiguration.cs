using Chinook.Core.Constants;
using Chinook.Core.ServiceModels;
using JsonApiFramework.ServiceModel.Configuration;

namespace Chinook.Core.HypemediaConfiguration
{
    class ArtistServiceModelConfiguration : ResourceTypeBuilder<Artist>
    {
        public ArtistServiceModelConfiguration()
        {
            // Ignore EF Core Navigation Properties from Serialization/Deserialization
            this.Attribute(a => a.Albums)
                .Ignore();

            // Expose JSON:API Relationships
            this.ToManyRelationship<Album>(AlbumResourceKeyWords.ToManyRelationShipKey);
        }
    }
}
