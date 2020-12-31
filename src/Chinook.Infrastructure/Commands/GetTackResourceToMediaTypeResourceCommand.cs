using Chinook.Core.ServiceModels;
using MediatR;

namespace Chinook.Infrastructure.Commands
{
    public class GetTackResourceToMediaTypeResourceCommand : IRequest<MediaType>
    {
        public int ResourceId { get; }

        public GetTackResourceToMediaTypeResourceCommand(int resourceId)
        {
            ResourceId = resourceId;
        }
    }
}
