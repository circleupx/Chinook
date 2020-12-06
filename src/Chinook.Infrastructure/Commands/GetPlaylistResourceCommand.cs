using Chinook.Core.ServiceModels;
using MediatR;

namespace Chinook.Infrastructure.Commands
{
    public class GetPlaylistResourceCommand : IRequest<Playlist>
    {
        public int ResourceId { get; }

        public GetPlaylistResourceCommand(int resourceId)
        {
            ResourceId = resourceId;
        }
    }
}
