using Chinook.Core.Extensions;
using Chinook.Core.Models;
using Chinook.Infrastructure.Commands;
using Chinook.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chinook.Infrastructure.Handlers
{
    public class GetAlbumResourceToTrackResourceCollectionHandler : IRequestHandler<GetAlbumResourceToTrackResourceCollectionCommand, IEnumerable<Track>>
    {
        private readonly ChinookDbContext _chinookDbContext;

        public GetAlbumResourceToTrackResourceCollectionHandler(ChinookDbContext chinookDbContext)
        {
            _chinookDbContext = chinookDbContext;
        }

        public async Task<IEnumerable<Track>> Handle(GetAlbumResourceToTrackResourceCollectionCommand request, CancellationToken cancellationToken)
        {
            var query = _chinookDbContext.Albums
                .TagWithSource()
                .Where(a => a.AlbumId == request.ResourceId)
                .Include(t => t.Tracks)
                .SelectMany(t => t.Tracks);
            
            return await query.ToListAsync(cancellationToken);
        }
    }
}
