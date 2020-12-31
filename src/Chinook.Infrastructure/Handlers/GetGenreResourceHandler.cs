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
    public class GetGenreResourceHandler : IRequestHandler<GetGenreResourceCommand, Genre>
    {
        private readonly ChinookDbContext _chinookDbContext;

        public GetGenreResourceHandler(ChinookDbContext chinookDbContext)
        {
            _chinookDbContext = chinookDbContext;
        }

        public async Task<Genre> Handle(GetGenreResourceCommand request, CancellationToken cancellationToken)
        {
            return await _chinookDbContext.Genres
                .TagWithSource()
                .FirstOrDefaultAsync(c => c.GenreId == request.ResourceId, cancellationToken);
        }
    }
}
