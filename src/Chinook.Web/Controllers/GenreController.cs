using Chinook.Core.Interfaces;
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
        public async Task<IActionResult> GetGenreResourceCollection()
        {
            var document = await _generResource.GetGenreResourceCollection();
            return Ok(document);
        }

        [Route(GenreRoutes.GenreResource)]
        public async Task<IActionResult> GetGenreResource(int resourceId)
        {
            var document = await _generResource.GetGenreResource(resourceId);
            return Ok(document);
        }

        [Route(GenreRoutes.GenreResourceToTrackResourceCollection)]
        public async Task<IActionResult> GetGenreResourceToTrackResourceCollection(int resourceId)
        {
            var document = await _generResource.GetGenreResourceToTrackResourceCollection(resourceId);
            return Ok(document);
        }
    }
}
