using Chinook.Core.Interfaces;
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
        public async Task<IActionResult> GetMediaTypeResourceCollection()
        {
            var document = await _mediaTypeResource.GetMediaTypeResourceCollection();
            return Ok(document);
        }

        [Route(MediaTypeRoutes.MediaTypeResource)]
        public async Task<IActionResult> GetMediaTypeResource(int resourceId)
        {
            var document = await _mediaTypeResource.GetMediaTypeResource(resourceId);
            return Ok(document);
        }

        [Route(MediaTypeRoutes.MediaTypeResourceToTrackResourceCollection)]
        public async Task<IActionResult> GetMediaTypeResourceToTrackResourceCollection(int resourceId)
        {
            var document = await _mediaTypeResource.GetMediaTypeResourceToTrackResourceCollection(resourceId);
            return Ok(document);
        }
    }
}
