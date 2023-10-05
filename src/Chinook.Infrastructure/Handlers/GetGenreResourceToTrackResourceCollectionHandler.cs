using Chinook.Core.Extensions;
using Chinook.Core.Models;
using Chinook.Infrastructure.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chinook.Infrastructure.Handlers
{
    public class GetGenreResourceToTrackResourceCollectionHandler : IRequestHandler<GetGenreResourceToTrackResourceCollectionCommand, IEnumerable<Track>>
    {
        private readonly ChinookDbContext _chinookDbContext;

        public GetGenreResourceToTrackResourceCollectionHandler(ChinookDbContext chinookDbContext)
        {
            _chinookDbContext = chinookDbContext;
        }

        public async Task<IEnumerable<Track>> Handle(GetGenreResourceToTrackResourceCollectionCommand request, CancellationToken cancellationToken)
        {
            var query = _chinookDbContext.Genres
                .TagWithSource()
                .Where(a => a.GenreId == request.ResourceId)
                .Include(t => t.Tracks)
                .SelectMany(t => t.Tracks);

            return await query.ToListAsync(cancellationToken);
        }
    }
}
