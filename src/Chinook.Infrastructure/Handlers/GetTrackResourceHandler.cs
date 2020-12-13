using Chinook.Core.Extensions;
using Chinook.Core.ServiceModels;
using Chinook.Infrastructure.Commands;
using Chinook.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Chinook.Infrastructure.Handlers
{
    public class GetTrackResourceHandler : IRequestHandler<GetTrackResourceCommand, Track>
    {
        private readonly ChinookDbContext _chinookDbContext;

        public GetTrackResourceHandler(ChinookDbContext chinookDbContext)
        {
            _chinookDbContext = chinookDbContext;
        }

        public async Task<Track> Handle(GetTrackResourceCommand request, CancellationToken cancellationToken)
        {
            return await _chinookDbContext.Tracks.TagWithSource().FirstOrDefaultAsync(c => c.TrackId == request.ResourceId, cancellationToken);
        }
    }
}
