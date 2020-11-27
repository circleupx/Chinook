using System.Collections.Generic;

namespace Chinook.Core.ServiceModels
{
    public partial class CustomerServiceModel
    {
        public CustomerServiceModel()
        {
            Invoices = new HashSet<InvoiceServiceModel>();
        }

        public long CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public long? SupportRepId { get; set; }

        public virtual EmployeeServiceModel SupportRep { get; set; }
        public virtual ICollection<InvoiceServiceModel> Invoices { get; set; }
    }
}
