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
    public class GetAlbumResourceCollectionHandler : IRequestHandler<GetAlbumResourceCollectionCommand, IEnumerable<Album>>
    {
        private readonly ChinookDbContext _chinookDbContext;

        public GetAlbumResourceCollectionHandler(ChinookDbContext chinookDbContext)
        {
            _chinookDbContext = chinookDbContext;
        }

        public async Task<IEnumerable<Album>> Handle(GetAlbumResourceCollectionCommand request, CancellationToken cancellationToken)
        {
            return await _chinookDbContext.Albums.TagWithSource().ToListAsync(cancellationToken);
        }
    }
}
