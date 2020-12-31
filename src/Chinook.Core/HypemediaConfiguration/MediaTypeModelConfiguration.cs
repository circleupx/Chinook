using Chinook.Core.Constants;
using Chinook.Core.ServiceModels;
using JsonApiFramework.ServiceModel.Configuration;

namespace Chinook.Core.HypemediaConfiguration
{
    class MediaTypeModelConfiguration : ResourceTypeBuilder<MediaType>
    {
        public MediaTypeModelConfiguration()
        {
            // Exclude EF Core Navigation Properties from Serialization/Deserialization
            this.Attribute(a => a.Tracks)
                .Ignore();

            // Expose JSON:API Relationships
            this.ToManyRelationship<Track>(TrackResourceKeyWords.ToManyRelationShipKey);
        }
    }
}
