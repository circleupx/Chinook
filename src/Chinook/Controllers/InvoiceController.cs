using Chinook.Web.Resources;
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
        public async Task<IActionResult> GetAlbumResourceCollection()
        {
            var document = await _invoiceResource.GetInvoiceResourceCollection();
            return Ok(document);
        }

        [Route(InvoiceRoutes.InvoiceResource)]
        public async Task<IActionResult> GetAlbumResource(int resourceId)
        {
            var document = await _invoiceResource.GetInvoiceResource(resourceId);
            return Ok(document);
        }
    }
}
