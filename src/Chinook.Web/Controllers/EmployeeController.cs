using Chinook.Core.Interfaces;
using Chinook.Web.Routes;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Chinook.Web.Controllers
{
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeResource _employeeResource;

        public EmployeeController(IEmployeeResource employeeResource)
        {
            _employeeResource = employeeResource;
        }

        [Route(EmployeeRoutes.EmployeeResourceCollection)]
        public async Task<IActionResult> GetEmployeeResourceCollection()
        {
            var document = await _employeeResource.GetEmployeeResourceCollection();
            return Ok(document);
        }

        [Route(EmployeeRoutes.EmployeeResource)]
        public async Task<IActionResult> GetEmployeeResource(int resourceId)
        {
            var document = await _employeeResource.GetEmployeeResource(resourceId);
            return Ok(document);
        }
    }
}
