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
    public class GetTrackResourceCollectionHandler : IRequestHandler<GetTrackResourceCollectionCommand, IEnumerable<Track>>
    {
        private readonly ChinookDbContext _chinookDbContext;

        public GetTrackResourceCollectionHandler(ChinookDbContext chinookDbContext)
        {
            _chinookDbContext = chinookDbContext;
        }

        public async Task<IEnumerable<Track>> Handle(GetTrackResourceCollectionCommand request, CancellationToken cancellationToken)
        {
            // Limit the amount of data return until pagination is implemented.
            return await _chinookDbContext.Tracks
                .TagWithSource()
                .Skip(0)
                .Take(100)
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
