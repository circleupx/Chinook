using Chinook.Core.ServiceModels;
using MediatR;

namespace Chinook.Infrastructure.Commands
{
    public class GetAlbumResourceToArtistResourceCommand : IRequest<Artist>
    {
        public int ResourceId { get; }

        public GetAlbumResourceToArtistResourceCommand(int resourceId)
        {
            ResourceId = resourceId;
        }
    }
}
