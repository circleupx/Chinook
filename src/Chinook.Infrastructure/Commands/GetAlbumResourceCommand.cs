using Chinook.Core.ServiceModels;
using MediatR;

namespace Chinook.Infrastructure.Commands
{
    public class GetAlbumResourceCommand : IRequest<Album>
    {
        public int ResourceId { get; }

        public GetAlbumResourceCommand(int resourceId)
        {
            ResourceId = resourceId;
        }
    }
}
