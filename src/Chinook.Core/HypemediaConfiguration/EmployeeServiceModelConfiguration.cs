using Chinook.Core.ServiceModels;
using JsonApiFramework.ServiceModel.Configuration;

namespace Chinook.Core.HypemediaConfiguration
{
    class EmployeeServiceModelConfiguration : ResourceTypeBuilder<Employee>
    {
        public EmployeeServiceModelConfiguration()
        {
            // Exclude EF Core Navigation Properties from Serialization/Deserialization
            this.Attribute(a => a.ReportsToNavigation)
                .Ignore();

            this.Attribute(a => a.Customers)
                .Ignore();

            this.Attribute(a => a.InverseReportsToNavigation)
                .Ignore();

            // Exclude Foreign Keys from Serialization/Deserialization
            this.Attribute(a => a.ReportsTo)
                .Ignore();
        }
    }
}
