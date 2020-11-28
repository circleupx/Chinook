using Chinook.Core.ServiceModels;
using JsonApiFramework.ServiceModel.Configuration;

namespace Chinook.Core.HypemediaConfiguration
{
    class InvoiceServiceModelConfiguration : ResourceTypeBuilder<Invoice>
    {
        public InvoiceServiceModelConfiguration()
        {
            // Ignore ER Core Navigation Properties
            this.Attribute(a => a.Customer)
                .Ignore();

            this.Attribute(a => a.InvoiceItems)
                .Ignore();

            // Ignore Foreign Keys
            this.Attribute(a => a.CustomerId)
                .Ignore();
        }
    }
}
