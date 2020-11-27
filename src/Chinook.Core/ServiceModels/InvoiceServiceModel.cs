using System.Collections.Generic;

namespace Chinook.Core.ServiceModels
{
    public partial class InvoiceServiceModel
    {
        public InvoiceServiceModel()
        {
            InvoiceItems = new HashSet<InvoiceItemServiceModel>();
        }

        public long InvoiceId { get; set; }
        public long CustomerId { get; set; }
        public byte[] InvoiceDate { get; set; }
        public string BillingAddress { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public string BillingCountry { get; set; }
        public string BillingPostalCode { get; set; }
        public byte[] Total { get; set; }

        public virtual CustomerServiceModel Customer { get; set; }
        public virtual ICollection<InvoiceItemServiceModel> InvoiceItems { get; set; }
    }
}
