using Chinook.Web.Resources;
using Chinook.Web.Routes;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Chinook.Web.Controllers
{
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumResource _albumResource;
        
        public AlbumController(IAlbumResource albumResource)
        {
            _albumResource = albumResource;
        }

        [Route(AlbumRoutes.AlbumResourceCollection)]
        public async Task<IActionResult> GetAlbumResourceCollection()
        {
            var document = await _albumResource.GetAlbumResourceCollection();
            return Ok(document);
        }

        [Route(AlbumRoutes.AlbumResource)]
        public async Task<IActionResult> GetAlbumResource(int resourceId)
        {
            var document = await _albumResource.GetAlbumResource(resourceId);
            return Ok(document);
        }

        [Route(AlbumRoutes.AlbumResourceToArtistResource)]
        public async Task<IActionResult> GetAlbumResourceToArtistResource(int resourceId)
        {
            var document = await _albumResource.GetAlbumResourceToArtistResource(resourceId);
            return Ok(document);
        }

        [Route(AlbumRoutes.AlbumResourceToTrackResourceCollection)]
        public async Task<IActionResult> GetAlbumResourceToTrackResourceCollection(int resourceId)
        {
            var document = await _albumResource.GetAlbumResourceToTrackResourceCollection(resourceId);
            return Ok(document);
        }
    }
}
