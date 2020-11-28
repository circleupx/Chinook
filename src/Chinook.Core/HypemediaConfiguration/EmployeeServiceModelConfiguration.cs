using Chinook.Core.ServiceModels;
using JsonApiFramework.ServiceModel.Configuration;

namespace Chinook.Core.HypemediaConfiguration
{
    class EmployeeServiceModelConfiguration : ResourceTypeBuilder<Employee>
    {
        public EmployeeServiceModelConfiguration()
        {
            // Ignore EF Core Navigation Properties
            this.Attribute(a => a.ReportsToNavigation)
                .Ignore();

            this.Attribute(a => a.Customers)
                .Ignore();

            this.Attribute(a => a.InverseReportsToNavigation)
                .Ignore();

            // Ignore Foreign Keys
            this.Attribute(a => a.ReportsTo)
                .Ignore();
        }
    }
}
