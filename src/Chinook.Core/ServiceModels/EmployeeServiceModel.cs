using System.Collections.Generic;

namespace Chinook.Core.ServiceModels
{
    public partial class EmployeeServiceModel
    {
        public EmployeeServiceModel()
        {
            Customers = new HashSet<CustomerServiceModel>();
            InverseReportsToNavigation = new HashSet<EmployeeServiceModel>();
        }

        public long EmployeeId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public long? ReportsTo { get; set; }
        public byte[] BirthDate { get; set; }
        public byte[] HireDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }

        public virtual EmployeeServiceModel ReportsToNavigation { get; set; }
        public virtual ICollection<CustomerServiceModel> Customers { get; set; }
        public virtual ICollection<EmployeeServiceModel> InverseReportsToNavigation { get; set; }
    }
}
