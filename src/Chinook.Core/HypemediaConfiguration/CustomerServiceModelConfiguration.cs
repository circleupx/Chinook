using Chinook.Core.ServiceModels;
using JsonApiFramework.ServiceModel.Configuration;

namespace Chinook.Core.HypemediaConfiguration
{
    class CustomerServiceModelConfiguration : ResourceTypeBuilder<Customer>
    {
        public CustomerServiceModelConfiguration()
        {
            // Exclude EF Core Navigation Properties from Serialization/Deserialization
            this.Attribute(a => a.SupportRep)
                .Ignore();

            this.Attribute(a => a.Invoices)
                .Ignore();

            // Exclude Foreign Keys from Serialization/Deserialization
            this.Attribute(a => a.SupportRepId)
                .Ignore();
        }
    }
}
