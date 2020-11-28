using Chinook.Core.ServiceModels;
using JsonApiFramework.ServiceModel.Configuration;

namespace Chinook.Core.HypemediaConfiguration
{
    class GenreServiceModelConfiguration : ResourceTypeBuilder<Genre>
    {
        public GenreServiceModelConfiguration()
        {
            // Ignore EF Core Navigation Properties
            this.Attribute(a => a.Tracks)
                .Ignore();
        }
    }
}
