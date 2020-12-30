using Chinook.Web.Resources;
using Chinook.Web.Routes;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Chinook.Web.Controllers
{
    [ApiController]
    public class TrackController : ControllerBase
    {
        private readonly ITrackResource _trackResource;

        public TrackController(ITrackResource trackResource)
        {
            _trackResource = trackResource;
        }

        [Route(TrackRoutes.TrackResourceCollection)]
        public async Task<IActionResult> GetAlbumResourceCollection()
        {
            var document = await _trackResource.GetTrackResourceCollection();
            return Ok(document);
        }

        [Route(TrackRoutes.TrackResource)]
        public async Task<IActionResult> GetAlbumResource(int resourceId)
        {
            var document = await _trackResource.GetTrackResource(resourceId);
            return Ok(document);
        }

        [Route(TrackRoutes.TrackResourceToAlbumResource)]
        public async Task<IActionResult> GetTrackResourceToAlbumResource(int resourceId)
        {
            var document = await _trackResource.GetTrackResourceToAlbumResource(resourceId);
            return Ok(document);
        }
    }
}
