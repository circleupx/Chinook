using Chinook.Core.ServiceModels;
using MediatR;

namespace Chinook.Infrastructure.Commands
{
    public class GetMediaTypeResourceCommand : IRequest<MediaType>
    {
        public int ResourceId { get; }

        public GetMediaTypeResourceCommand(int resourceId)
        {
            ResourceId = resourceId;
        }
    }
}
