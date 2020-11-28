using Chinook.Web.Resources;
using Chinook.Web.Routes;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Chinook.Web.Controllers
{
    [ApiController]
    public class InvoiceItemController : ControllerBase
    {
        private readonly IInvoiceItemResource _invoiceItemResource;

        public InvoiceItemController(IInvoiceItemResource invoiceItemResource)
        {
            _invoiceItemResource = invoiceItemResource;
        }

        [Route(InvoiceItemsRoutes.InvoiceItemsResourceCollection)]
        public async Task<IActionResult> GetAlbumResourceCollection()
        {
            var document = await _invoiceItemResource.GetInvoiceItemResourceCollection();
            return Ok(document);
        }

        [Route(InvoiceItemsRoutes.InvoiceItemsResource)]
        public async Task<IActionResult> GetAlbumResource(int resourceId)
        {
            var document = await _invoiceItemResource.GetInvoiceItemResource(resourceId);
            return Ok(document);
        }
    }
}
