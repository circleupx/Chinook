using Chinook.Core.Extensions;
using Chinook.Core.ServiceModels;
using Chinook.Infrastructure.Commands;
using Chinook.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chinook.Infrastructure.Handlers
{
    public class GetTackResourceToMediaTypeResourceHandler : IRequestHandler<GetTackResourceToMediaTypeResourceCommand, MediaType>
    {
        private readonly ChinookDbContext _chinookDbContext;

        public GetTackResourceToMediaTypeResourceHandler(ChinookDbContext chinookDbContext)
        {
            _chinookDbContext = chinookDbContext;
        }

        public async Task<MediaType> Handle(GetTackResourceToMediaTypeResourceCommand request, CancellationToken cancellationToken)
        {
            var query = _chinookDbContext.Tracks
                .TagWithSource()
                .Where(t => t.TrackId == request.ResourceId)
                .Select(m => m.MediaType);

            return await query.FirstOrDefaultAsync(cancellationToken: cancellationToken);
        }
    }
}
