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
    public class GetTackResourceToGenreResourceHandler : IRequestHandler<GetTackResourceToGenreResourceCommand, Genre>
    {
        private readonly ChinookDbContext _chinookDbContext;

        public GetTackResourceToGenreResourceHandler(ChinookDbContext chinookDbContext)
        {
            _chinookDbContext = chinookDbContext;
        }

        public async Task<Genre> Handle(GetTackResourceToGenreResourceCommand request, CancellationToken cancellationToken)
        {
            var query = _chinookDbContext.Tracks
                .TagWithSource()
                .Where(t => t.TrackId == request.ResourceId)
                .Select(t => t.Genre);

            return await query.FirstOrDefaultAsync(cancellationToken: cancellationToken);
        }
    }
}
