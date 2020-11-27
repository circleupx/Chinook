using Chinook.Web.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Chinook.Web.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger logger;
        private readonly HomeResource homeResource;

        public HomeController(ILogger<HomeController> logger, HomeResource homeResource)
        {
            this.logger = logger;
            this.homeResource = homeResource;
        }

        [Route("")]
        public async Task<IActionResult> GetHomeResource()
        {
            var homeDocument = await homeResource.GetHomeDocument();
            return Ok(homeDocument);
        }
    }
}
