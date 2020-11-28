using Chinook.Core.ServiceModels;
using JsonApiFramework.ServiceModel.Configuration;

namespace Chinook.Core.HypemediaConfiguration
{
    class CustomerServiceModelConfiguration : ResourceTypeBuilder<Customer>
    {
        public CustomerServiceModelConfiguration()
        {
            // Ignore EF Core Navigation Properties
            this.Attribute(a => a.SupportRep)
                .Ignore();

            this.Attribute(a => a.Invoices)
                .Ignore();

            // Ignore Foreign Keys
            this.Attribute(a => a.SupportRepId)
                .Ignore();
        }
    }
}
