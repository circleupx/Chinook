using Chinook.Core.ServiceModels;
using MediatR;

namespace Chinook.Infrastructure.Commands
{
    public class GetTackResourceToAlbumResourceCommand : IRequest<Album>
    {
        public int ResourceId { get; }

        public GetTackResourceToAlbumResourceCommand(int resourceId)
        {
            ResourceId = resourceId;
        }
    }
}
