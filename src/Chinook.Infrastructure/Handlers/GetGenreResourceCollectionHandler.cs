using Chinook.Core.Extensions;
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
    public class GetGenreResourceCollectionHandler : IRequestHandler<GetGenreResourceCollectionCommand, IEnumerable<Genre>>
    {
        private readonly ChinookDbContext _chinookDbContext;

        public GetGenreResourceCollectionHandler(ChinookDbContext chinookDbContext)
        {
            _chinookDbContext = chinookDbContext;
        }

        public async Task<IEnumerable<Genre>> Handle(GetGenreResourceCollectionCommand request, CancellationToken cancellationToken)
        {
            return await _chinookDbContext.Genres.TagWithSource().ToListAsync(cancellationToken);
        }
    }
}
