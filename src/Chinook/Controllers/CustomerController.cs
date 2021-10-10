using Chinook.Web.Resources;
using Chinook.Web.Routes;
using JsonApiFramework.JsonApi;
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

        [HttpGet]
        [Route(CustomerRoutes.CustomerSchema)]
        public async Task<IActionResult> GetCustomerSchema()
        {
            var schemaFile = System.IO.File.OpenText("schemas/customer-json-schema.json");
            var schemaContent = await schemaFile.ReadToEndAsync();
            return Ok(schemaContent);
        }

        [HttpGet]
        [Route(CustomerRoutes.CustomerResourceCollection)]
        public async Task<IActionResult> GetCustomerResourceCollection()
        {
            var document = await _customerResource.GetCustomerResourceCollection();
            return Ok(document);
        }

        [HttpGet]
        [Route(CustomerRoutes.CustomerResource)]
        public async Task<IActionResult> GetCustomerResource(int resourceId)
        {
            var document = await _customerResource.GetCustomerResource(resourceId);
            return Ok(document);
        }

        [HttpGet]
        [Route(CustomerRoutes.CustomerResourceToInvoiceResourceCollection)]
        public async Task<IActionResult> GetCustomerResourceToInvoiceResourceCollection(int resourceId)
        {
            var document = await _customerResource.GetCustomerResourceToInvoiceResourceCollection(resourceId);
            return Ok(document);
        }

        [HttpPost]
        [Route(CustomerRoutes.CustomerResourceCollection)]
        public async Task<IActionResult> CreateCustomerResource([FromBody] Document jsonApiDocument)
        {
            var documnet = await _customerResource.CreateCustomerResource(jsonApiDocument);
            return Created(documnet.SelfLink(), documnet);
        }

        [HttpPatch]
        [Route(CustomerRoutes.CustomerResource)]
        public async Task<IActionResult> UpdateCustomerResource ([FromBody] Document jsonApiDocument)
        {
            return Ok(jsonApiDocument);
        }
    }
}