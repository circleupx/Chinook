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
    public class GetAlbumResourceHandler : IRequestHandler<GetAlbumResourceCommand, Album>
    {
        private readonly ChinookDbContext _chinookDbContext;

        public GetAlbumResourceHandler(ChinookDbContext chinookDbContext)
        {
            _chinookDbContext = chinookDbContext;
        }

        public async Task<Album> Handle(GetAlbumResourceCommand request, CancellationToken cancellationToken)
        {
            return await _chinookDbContext.Albums.TagWithSource().FirstOrDefaultAsync(a => a.AlbumId == request.ResourceId, cancellationToken);
        }
    }
}
