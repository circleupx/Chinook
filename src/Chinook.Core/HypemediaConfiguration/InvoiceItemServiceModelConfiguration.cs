using Chinook.Core.Constants;
using Chinook.Core.ServiceModels;
using JsonApiFramework.ServiceModel.Configuration;

namespace Chinook.Core.HypemediaConfiguration
{
    class InvoiceItemServiceModelConfiguration : ResourceTypeBuilder<InvoiceItem>
    {
        public InvoiceItemServiceModelConfiguration()
        {
            /* Set InvoiceLineId as the JSON:API id. Unlike the other entities, InvoiceItem does not follow standard conventions.
             * The primary key on the SQL lite DB should be named InvoiceItemId, but for some reason the creators of the project broke this covention
             * on this entity. Since it doesn't follow standard conventions, we need to manually map it here 
             * in order for JsonApiFramework to work.
            */
            this.ResourceIdentity(p => p.InvoiceLineId);

            // Ignore Id on JSON:API Object Attributes
            this.Attribute(a => a.InvoiceLineId)
                .Ignore();

            // Exclude EF Core Navigation Properties from Serialization/Deserialization
            this.Attribute(a => a.Invoice)
                .Ignore();

            this.Attribute(a => a.Track)
                .Ignore();

            // Exclude Foreign Keys from Serialization/Deserialization
            this.Attribute(a => a.InvoiceId)
                .Ignore();

            this.Attribute(a => a.TrackId)
                .Ignore();

            // Expose JSON:API Relationships
            this.ToOneRelationship<Invoice>(InvoiceResourceKeyWords.ToOneRelationshipKey);
            this.ToOneRelationship<Track>(TrackResourceKeyWords.ToOneRelationshipKey);
        }
    }
}
