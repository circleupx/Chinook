using Chinook.Core.Models;
using MediatR;
using System.Collections.Generic;

namespace Chinook.Infrastructure.Commands
{
    public class GetGenreResourceToTrackResourceCollectionCommand : IRequest<IEnumerable<Track>>
    {
        public int ResourceId { get; }

        public GetGenreResourceToTrackResourceCollectionCommand(int resourceId)
        {
            ResourceId = resourceId;
        }
    }
}
