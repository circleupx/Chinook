using Chinook.Core.Constants;
using Chinook.Core.Models;
using JsonApiFramework.ServiceModel.Configuration;

namespace Chinook.Core.HypemediaConfiguration
{
    class GenreServiceModelConfiguration : ResourceTypeBuilder<Genre>
    {
        public GenreServiceModelConfiguration()
        {
            // Ignore EF Core Navigation Properties from Serialization/Deserialization 
            this.Attribute(a => a.Tracks)
                .Ignore();

            // Expose JSON:API Relationships
            this.ToManyRelationship<Track>(TrackResourceKeyWords.ToManyRelationShipKey);
        }
    }
}
