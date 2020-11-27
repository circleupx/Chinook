using Chinook.Core;
using Chinook.Core.Constants;
using Chinook.Core.Extensions;
using Chinook.Infrastructure.Database;
using JsonApiFramework.JsonApi;
using JsonApiFramework.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Chinook.Web.Controllers
{
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ChinookDbContext _chinookContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CustomerController(ILogger<CustomerController> logger, ChinookDbContext chinookContext, IHttpContextAccessor httpContextAccessor)
        {
           _logger = logger;
           _chinookContext = chinookContext;
           _httpContextAccessor = httpContextAccessor;
        }

        [Route(CustomerResourceKeyWords.Self)]
        public async Task<IActionResult> GetCustomersResourceCollection()
        {
            var customerResourceCollection = await _chinookContext.Customers.ToListAsync();
            var currentRequestUri = _httpContextAccessor.HttpContext.GetCurrentRequestUri();

            using var chinookDocumentContext = new ChinookJsonApiDocumentContext(currentRequestUri);
            var document = chinookDocumentContext
                .NewDocument(currentRequestUri)
                .SetJsonApiVersion(JsonApiVersion.Version10)
                    .Links()
                        .AddSelfLink()
                    .LinksEnd()
                    .ResourceCollection(customerResourceCollection)
                        .Links()
                            .AddSelfLink()
                        .LinksEnd()
                    .ResourceCollectionEnd()
                .WriteDocument();

            return Ok(document);
        }
    }
}
