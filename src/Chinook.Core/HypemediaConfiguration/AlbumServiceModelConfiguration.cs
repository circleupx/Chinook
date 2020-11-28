using Chinook.Core.ServiceModels;
using JsonApiFramework.ServiceModel.Configuration;

namespace Chinook.Core.HypemediaConfiguration
{
    class AlbumServiceModelConfiguration : ResourceTypeBuilder<Album>
    {
        public AlbumServiceModelConfiguration()
        {
            // Ignore ER Core Navigation Properties
            this.Attribute(a => a.Artist)
                .Ignore();

            this.Attribute(a => a.Tracks)
                .Ignore();

            // Ignore Foreign Keys

            this.Attribute(a => a.ArtistId)
                .Ignore();
        }
    }
}
