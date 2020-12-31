using Chinook.Web.Resources;
using Chinook.Web.Routes;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Chinook.Web.Controllers
{
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerResource _customerResource;

        public CustomerController(ICustomerResource customerResource)
        {
            _customerResource = customerResource;
        }

        [Route(CustomerRoutes.CustomerResourceCollection)]
        public async Task<IActionResult> GetCustomerResourceCollection()
        {
            var document = await _customerResource.GetCustomerResourceCollection();
            return Ok(document);
        }

        [Route(CustomerRoutes.CustomerResource)]
        public async Task<IActionResult> GetCustomerResource(int resourceId)
        {
            var document = await _customerResource.GetCustomerResource(resourceId);
            return Ok(document);
        }

        [Route(CustomerRoutes.CustomerResourceToInvoiceResourceCollection)]
        public async Task<IActionResult> GetCustomerResourceToInvoiceResourceCollection(int resourceId)
        {
            var document = await _customerResource.GetCustomerResourceToInvoiceResourceCollection(resourceId);
            return Ok(document);
        }
    }
}