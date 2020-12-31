using Chinook.Core.ServiceModels;
using MediatR;
using System.Collections.Generic;

namespace Chinook.Infrastructure.Commands
{
    public class GetMediaTypeResourceToTrackResourceCollectionCommand : IRequest<IEnumerable<Track>>
    {
        public int ResourceId { get; }

        public GetMediaTypeResourceToTrackResourceCollectionCommand(int resourceId)
        {
            ResourceId = resourceId;
        }
    }
}
