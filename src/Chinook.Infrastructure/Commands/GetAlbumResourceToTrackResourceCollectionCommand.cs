using Chinook.Core.Models;
using MediatR;
using System.Collections.Generic;

namespace Chinook.Infrastructure.Commands
{
    public class GetAlbumResourceToTrackResourceCollectionCommand : IRequest<IEnumerable<Track>>
    {
        public int ResourceId { get; }

        public GetAlbumResourceToTrackResourceCollectionCommand(int resourceId)
        {
            ResourceId = resourceId;
        }
    }
}
