using Chinook.Core.ServiceModels;
using JsonApiFramework.ServiceModel.Configuration;

namespace Chinook.Core.Hypemedia.Configurations
{
    class HomeServiceModelConfiguration : ResourceTypeBuilder<Home>
    {
        private const string JsonApiType = "home";

        public HomeServiceModelConfiguration()
        {
            Hypermedia()
                .SetApiCollectionPathSegment(string.Empty);

            ResourceIdentity()
                .SetApiType(JsonApiType);
        }
    }
}
