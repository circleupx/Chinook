using JsonApiFramework.ServiceModel.Configuration;

namespace Chinook.Core.ServiceModels.Configurations
{
    class HomeServiceModelConfiguration : ResourceTypeBuilder<HomeServiceModel>
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
