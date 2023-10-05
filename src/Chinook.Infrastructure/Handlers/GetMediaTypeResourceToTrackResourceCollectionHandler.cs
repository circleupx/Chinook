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
    public class GetMediaTypeResourceToTrackResourceCollectionHandler : IRequestHandler<GetMediaTypeResourceToTrackResourceCollectionCommand, IEnumerable<Track>>
    {
        private readonly ChinookDbContext _chinookDbContext;

        public GetMediaTypeResourceToTrackResourceCollectionHandler(ChinookDbContext chinookDbContext)
        {
            _chinookDbContext = chinookDbContext;
        }

        public async Task<IEnumerable<Track>> Handle(GetMediaTypeResourceToTrackResourceCollectionCommand request, CancellationToken cancellationToken)
        {
            var query = _chinookDbContext.MediaTypes
                .TagWithSource()
                .Where(m => m.MediaTypeId == request.ResourceId)
                .SelectMany(t => t.Tracks);

            return await query.ToListAsync(cancellationToken);
        }
    }
}
