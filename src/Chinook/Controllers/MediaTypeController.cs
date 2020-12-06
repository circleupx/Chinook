using Chinook.Web.Resources;
using Chinook.Web.Routes;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Chinook.Web.Controllers
{
    [ApiController]
    public class MediaTypeController : ControllerBase
    {
        private readonly IMediaTypeResource _mediaTypeResource;

        public MediaTypeController(IMediaTypeResource mediaTypeResource)
        {
            _mediaTypeResource = mediaTypeResource;
        }

        [Route(MediaTypeRoutes.MediaTypeResourceCollection)]
        public async Task<IActionResult> GetAlbumResourceCollection()
        {
            var document = await _mediaTypeResource.GetMediaTypeResourceCollection();
            return Ok(document);
        }

        [Route(MediaTypeRoutes.MediaTypeResource)]
        public async Task<IActionResult> GetAlbumResource(int resourceId)
        {
            var document = await _mediaTypeResource.GetMediaTypeResource(resourceId);
            return Ok(document);
        }
    }
}
