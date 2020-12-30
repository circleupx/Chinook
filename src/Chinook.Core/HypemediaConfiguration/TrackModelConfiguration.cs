using Chinook.Core.Constants;
using Chinook.Core.ServiceModels;
using JsonApiFramework.ServiceModel.Configuration;

namespace Chinook.Core.HypemediaConfiguration
{
    class TrackModelConfiguration : ResourceTypeBuilder<Track>
    {
        public TrackModelConfiguration()
        {
            // Exclude EF Core Navigation Properties from Serialization/Deserialization
            this.Attribute(a => a.Album)
                .Ignore();

            this.Attribute(a => a.Genre)
                .Ignore();

            this.Attribute(a => a.MediaType)
                .Ignore();

            this.Attribute(a => a.InvoiceItems)
                .Ignore();

            this.Attribute(a => a.PlaylistTrack)
                .Ignore();

            // Exclude Foreign Keys from Serialization/Deserialization
            this.Attribute(a => a.MediaTypeId)
                .Ignore();

            this.Attribute(a => a.AlbumId)
                .Ignore();

            this.Attribute(a => a.GenreId)
                .Ignore();

            // Expose JSON:API Relationships
            this.ToOneRelationship<Album>(AlbumResourceKeyWords.ToOneRelationshipKey);
            this.ToOneRelationship<Genre>(GenreResourceKeyWords.ToOneRelationshipKey);
            this.ToOneRelationship<MediaType>(MediaTypeResourceKeyWords.ToOneRelationshipKey);
            this.ToManyRelationship<InvoiceItem>(InvoiceItemResourceKeyWords.ToManyRelationShipKey);
            this.ToManyRelationship<PlaylistTrack>(PlaylistResourceKeyWords.ToManyRelationShipKey);
        }
    }
}
