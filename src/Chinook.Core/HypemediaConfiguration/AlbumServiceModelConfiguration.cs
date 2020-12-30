using Chinook.Core.Constants;
using Chinook.Core.ServiceModels;
using JsonApiFramework.ServiceModel.Configuration;

namespace Chinook.Core.HypemediaConfiguration
{
    class AlbumServiceModelConfiguration : ResourceTypeBuilder<Album>
    {
        public AlbumServiceModelConfiguration()
        {
            // Exclude EF Core Navigation Properties from Serialization/Deserialization
            this.Attribute(a => a.Artist)
                .Ignore();

            this.Attribute(a => a.Tracks)
                .Ignore();

            // Exclude Foreign Keys from Serialization/Deserialization
            this.Attribute(a => a.ArtistId)
                .Ignore();

            // Expose JSON:API Relationships
            this.ToOneRelationship<Artist>(ArtistResourceKeyWords.ToOneRelationshipKey);
            this.ToManyRelationship<Track>(TrackResourceKeyWords.ToManyRelationShipKey);
        }
    }
}
