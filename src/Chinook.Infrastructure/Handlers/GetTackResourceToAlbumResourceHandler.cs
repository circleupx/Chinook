using Chinook.Core.Extensions;
using Chinook.Core.Models;
using Chinook.Infrastructure.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chinook.Infrastructure.Handlers
{
    public class GetTackResourceToAlbumResourceHandler : IRequestHandler<GetTackResourceToAlbumResourceCommand, Album>
    {
        private readonly ChinookDbContext _chinookDbContext;

        public GetTackResourceToAlbumResourceHandler(ChinookDbContext chinookDbContext)
        {
            _chinookDbContext = chinookDbContext;
        }

        public async Task<Album> Handle(GetTackResourceToAlbumResourceCommand request, CancellationToken cancellationToken)
        {
            var query = _chinookDbContext.Tracks
                .TagWithSource()
                .Where(t => t.TrackId == request.ResourceId)
                .Select(t => t.Album);

            return await query.FirstOrDefaultAsync(cancellationToken: cancellationToken);
        }
    }
}
