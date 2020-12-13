using Chinook.Core.Extensions;
using Chinook.Core.ServiceModels;
using Chinook.Infrastructure.Commands;
using Chinook.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chinook.Infrastructure.Handlers
{
    public class GetArtistResourceToAlbumResourceCollectionHandler : IRequestHandler<GetArtistResourceToAlbumResourceCollectionCommand, IEnumerable<Album>>
    {
        private readonly ChinookDbContext _chinookDbContext;

        public GetArtistResourceToAlbumResourceCollectionHandler(ChinookDbContext chinookDbContext)
        {
            _chinookDbContext = chinookDbContext;
        }

        public async Task<IEnumerable<Album>> Handle(GetArtistResourceToAlbumResourceCollectionCommand request, CancellationToken cancellationToken)
        {
            return await _chinookDbContext.Albums.TagWithSource().Where(a => a.ArtistId == request.ResourceId).ToListAsync();
        }
    }
}
