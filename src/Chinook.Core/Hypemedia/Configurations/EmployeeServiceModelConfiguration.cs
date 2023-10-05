using Chinook.Core.Models;
using JsonApiFramework.ServiceModel.Configuration;

namespace Chinook.Core.HypemediaConfiguration
{
    class EmployeeServiceModelConfiguration : ResourceTypeBuilder<Employee>
    {
        public EmployeeServiceModelConfiguration()
        {

            this.Attribute(a => a.Customers)
                .Ignore();
        }
    }
}
