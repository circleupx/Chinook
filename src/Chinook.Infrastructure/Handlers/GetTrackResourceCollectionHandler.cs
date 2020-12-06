using Chinook.Core.ServiceModels;
using Chinook.Infrastructure.Commands;
using Chinook.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
            return await _chinookDbContext.Tracks.ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
