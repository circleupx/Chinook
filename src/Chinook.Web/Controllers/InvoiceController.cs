using Chinook.Core.Interfaces;
using Chinook.Web.Routes;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Chinook.Web.Controllers
{
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceResource _invoiceResource;

        public InvoiceController(IInvoiceResource invoiceResource)
        {
            _invoiceResource = invoiceResource;
        }

        [Route(InvoiceRoutes.InvoiceResourceCollection)]
        public async Task<IActionResult> GetInvoiceResourceCollection()
        {
            var document = await _invoiceResource.GetInvoiceResourceCollection();
            return Ok(document);
        }

        [Route(InvoiceRoutes.InvoiceResource)]
        public async Task<IActionResult> GetInvoiceResource(int resourceId)
        {
            var document = await _invoiceResource.GetInvoiceResource(resourceId);
            return Ok(document);
        }

        [Route(InvoiceRoutes.InvoiceResourceToCustomerResource)]
        public async Task<IActionResult> GetInvoiceResourceToCustomerResource(int resourceId)
        {
            var document = await _invoiceResource.GetInvoiceResourceToCustomerResource(resourceId);
            return Ok(document);
        }

        [Route(InvoiceRoutes.InvoiceResourceToInvoiceItemResourceCollection)]
        public async Task<IActionResult> GetInvoiceResourceToInvoiceItemResourceCollection(int resourceId)
        {
            var document = await _invoiceResource.GetInvoiceResourceToInvoiceItemResourceCollection(resourceId);
            return Ok(document);
        }
    }
}
