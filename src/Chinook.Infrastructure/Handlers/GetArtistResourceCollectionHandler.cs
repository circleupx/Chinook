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
    public class GetArtistResourceCollectionHandler : IRequestHandler<GetArtistResourceCollectionCommand, IEnumerable<Artist>>
    {
        private readonly ChinookDbContext _chinookDbContext;

        public GetArtistResourceCollectionHandler(ChinookDbContext chinookDbContext)
        {
            _chinookDbContext = chinookDbContext;
        }

        public async Task<IEnumerable<Artist>> Handle(GetArtistResourceCollectionCommand request, CancellationToken cancellationToken)
        {
            return await _chinookDbContext.Artists
                .TagWithSource()
                .ToListAsync(cancellationToken);
        }
    }
}
