using Chinook.Web.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Chinook.Web.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly HomeResource homeResource;
        
        public HomeController( HomeResource homeResource)
        {
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
