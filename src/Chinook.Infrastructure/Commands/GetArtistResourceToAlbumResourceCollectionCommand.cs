using Chinook.Core.ServiceModels;
using MediatR;
using System.Collections.Generic;

namespace Chinook.Infrastructure.Commands
{
    public class GetArtistResourceToAlbumResourceCollectionCommand : IRequest<IEnumerable<Album>>
    {
        public int ResourceId { get; }

        public GetArtistResourceToAlbumResourceCollectionCommand(int resourceId)
        {
            ResourceId = resourceId;
        }
    }
}
