using Chinook.Core.Constants;
using Chinook.Core.ServiceModels;
using JsonApiFramework.ServiceModel.Configuration;

namespace Chinook.Core.HypemediaConfiguration
{
    class ArtistServiceModelConfiguration : ResourceTypeBuilder<Artist>
    {
        public ArtistServiceModelConfiguration()
        {
            // Ignore ER Core Navigation Properties
            this.Attribute(a => a.Albums)
                .Ignore();

            this.ToManyRelationship<Album>(AlbumResourceKeyWords.ToManyRelationShipKey);
        }
    }
}
