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
    public class GetPlaylistResourceHandler : IRequestHandler<GetPlaylistResourceCommand, Playlist>
    {
        private readonly ChinookDbContext _chinookDbContext;

        public GetPlaylistResourceHandler(ChinookDbContext chinookDbContext)
        {
            _chinookDbContext = chinookDbContext;
        }

        public async Task<Playlist> Handle(GetPlaylistResourceCommand request, CancellationToken cancellationToken)
        {
            return await _chinookDbContext.Playlists.TagWithSource().FirstOrDefaultAsync(c => c.PlaylistId == request.ResourceId, cancellationToken);
        }
    }
}
