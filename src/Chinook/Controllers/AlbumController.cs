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
    }
}
