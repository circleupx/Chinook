using Chinook.Web.Resources;
using Chinook.Web.Routes;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Chinook.Web.Controllers
{
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenerResource _generResource;

        public GenreController(IGenerResource generResource)
        {
            _generResource = generResource;
        }

        [Route(GenreRoutes.GenreResourceCollection)]
        public async Task<IActionResult> GetAlbumResourceCollection()
        {
            var document = await _generResource.GetGenreResourceCollection();
            return Ok(document);
        }

        [Route(GenreRoutes.GenreResource)]
        public async Task<IActionResult> GetAlbumResource(int resourceId)
        {
            var document = await _generResource.GetGenreResource(resourceId);
            return Ok(document);
        }
    }
}
