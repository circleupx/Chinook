using Chinook.Core.Interfaces;
using Chinook.Web.Routes;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Chinook.Web.Controllers
{
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        private readonly IPlaylistResource _playlistResource;

        public PlaylistController(IPlaylistResource playlistResource)
        {
            _playlistResource = playlistResource;
        }

        [Route(PlaylistRoutes.PlaylistResourceCollection)]
        public async Task<IActionResult> GetAlbumResourceCollection()
        {
            var document = await _playlistResource.GetPlaylistResourceCollection();
            return Ok(document);
        }

        [Route(PlaylistRoutes.PlaylistResource)]
        public async Task<IActionResult> GetAlbumResource(int resourceId)
        {
            var document = await _playlistResource.GetPlaylistResource(resourceId);
            return Ok(document);
        }
    }
}
