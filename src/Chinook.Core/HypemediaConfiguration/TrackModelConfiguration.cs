using Chinook.Core.ServiceModels;
using JsonApiFramework.ServiceModel.Configuration;

namespace Chinook.Core.HypemediaConfiguration
{
    class TrackModelConfiguration : ResourceTypeBuilder<Track>
    {
        public TrackModelConfiguration()
        {
            // Ignore ER Core Navigation Properties
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

            // Ignore Foreign Keys
            this.Attribute(a => a.MediaTypeId)
                .Ignore();

            this.Attribute(a => a.AlbumId)
                .Ignore();

            this.Attribute(a => a.GenreId)
                .Ignore();
        }
    }
}
