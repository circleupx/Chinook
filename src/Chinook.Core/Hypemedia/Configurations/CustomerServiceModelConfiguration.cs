using Chinook.Core.ServiceModels;
using JsonApiFramework.ServiceModel.Configuration;

namespace Chinook.Core.Hypemedia.Configurations
{
    class CustomerServiceModelConfiguration : ResourceTypeBuilder<CustomerServiceModel>
    {
        public CustomerServiceModelConfiguration()
        {
            ResourceIdentity(nameof(CustomerServiceModel.CustomerId), typeof(long));
        }
    }
}
