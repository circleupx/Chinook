using Chinook.Core.Constants;
using Chinook.Core.ServiceModels;
using JsonApiFramework.ServiceModel.Configuration;

namespace Chinook.Core.HypemediaConfiguration
{
    class InvoiceServiceModelConfiguration : ResourceTypeBuilder<Invoice>
    {
        public InvoiceServiceModelConfiguration()
        {
            // Exclude EF Core Navigation Properties from Serialization/Deserialization
            this.Attribute(a => a.Customer)
                .Ignore();

            this.Attribute(a => a.InvoiceItems)
                .Ignore();

            // Exclude Foreign Keys from Serialization/Deserialization
            this.Attribute(a => a.CustomerId)
                .Ignore();

            // Expose JSON:API Relationships
            this.ToOneRelationship<Customer>(CustomerResourceKeyWords.ToOneRelationshipKey);
            this.ToManyRelationship<InvoiceItem>(InvoiceItemResourceKeyWords.ToManyRelationShipKey);
        }
    }
}
