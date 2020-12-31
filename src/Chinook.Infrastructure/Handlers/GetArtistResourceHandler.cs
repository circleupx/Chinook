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
    public class GetArtistResourceHandler : IRequestHandler<GetArtistResourceCommand, Artist>
    {
        private readonly ChinookDbContext _chinookDbContext;

        public GetArtistResourceHandler(ChinookDbContext chinookDbContext)
        {
            _chinookDbContext = chinookDbContext;
        }

        public async Task<Artist> Handle(GetArtistResourceCommand request, CancellationToken cancellationToken)
        {
            return await _chinookDbContext.Artists
                .TagWithSource()
                .FirstOrDefaultAsync(c => c.ArtistId == request.ResourceId, cancellationToken);
        }
    }
}
