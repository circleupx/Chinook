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

        [Route(TrackRoutes.PlaylistResourceCollection)]
        public async Task<IActionResult> GetAlbumResourceCollection()
        {
            var document = await _trackResource.GetTrackResourceCollection();
            return Ok(document);
        }

        [Route(TrackRoutes.PlaylistResource)]
        public async Task<IActionResult> GetAlbumResource(int resourceId)
        {
            var document = await _trackResource.GetTrackResource(resourceId);
            return Ok(document);
        }
    }
}
