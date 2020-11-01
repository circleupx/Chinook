using JsonApiFramework.ServiceModel;
using JsonApiFramework.ServiceModel.Configuration;
using System;

namespace Chinook.Core.ServiceModels.Configurations
{
    class CustomerServiceModelConfiguration : ResourceTypeBuilder<Customers>
    {
        public CustomerServiceModelConfiguration()
        {
            ResourceIdentity(nameof(Customers.CustomerId),typeof(long));
        }
    }
}
