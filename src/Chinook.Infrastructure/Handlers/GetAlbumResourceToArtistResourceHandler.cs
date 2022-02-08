using Chinook.Core.Extensions;
using Chinook.Core.Models;
using Chinook.Infrastructure.Commands;
using Chinook.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chinook.Infrastructure.Handlers
{
    public class GetAlbumResourceToArtistResourceHandler : IRequestHandler<GetAlbumResourceToArtistResourceCommand, Artist>
    {
        private readonly ChinookDbContext _chinookDbContext;

        public GetAlbumResourceToArtistResourceHandler(ChinookDbContext chinookDbContext)
        {
            _chinookDbContext = chinookDbContext;
        }

        public async Task<Artist> Handle(GetAlbumResourceToArtistResourceCommand request, CancellationToken cancellationToken)
        {
            var query = _chinookDbContext.Albums
                .TagWithSource()
                .Where(a => a.AlbumId == request.ResourceId)
                .Select(d => d.Artist);
            return await query.SingleOrDefaultAsync(cancellationToken);
        }
    }
}
