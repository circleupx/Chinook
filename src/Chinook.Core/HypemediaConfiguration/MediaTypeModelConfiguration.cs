using Chinook.Core.ServiceModels;
using JsonApiFramework.ServiceModel.Configuration;

namespace Chinook.Core.HypemediaConfiguration
{
    class MediaTypeModelConfiguration : ResourceTypeBuilder<MediaType>
    {
        public MediaTypeModelConfiguration()
        {
            // Ignore ER Core Navigation Properties
            this.Attribute(a => a.Tracks)
                .Ignore();
        }
    }
}
