﻿using Chinook.Web.Resources;
using Chinook.Web.Routes;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Chinook.Web.Controllers
{
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistResource _artistResource;

        public ArtistController(IArtistResource artistResource)
        {
            _artistResource = artistResource;
        }

        [Route(ArtistRoutes.ArtistResourceCollection)]
        public async Task<IActionResult> GetAlbumResourceCollection()
        {
            var document = await _artistResource.GetArtistResourceCollection();
            return Ok(document);
        }

        [Route(ArtistRoutes.ArtistResource)]
        public async Task<IActionResult> GetAlbumResource(int resourceId)
        {
            var document = await _artistResource.GetArtistResource(resourceId);
            return Ok(document);
        }
    }
}
