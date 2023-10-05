using Chinook.Core;
using Chinook.Core.Models;
using MediatR;
using System.Collections.Generic;

namespace Chinook.Infrastructure.Commands
{
    public class GetAlbumResourceCollectionCommand : IRequest<IEnumerable<Album>>
    {
        public readonly ResoureQuerySpecification querySpecification;

        public GetAlbumResourceCollectionCommand(ResoureQuerySpecification resourceQueryBuilder)
        {
            querySpecification = resourceQueryBuilder;
        }
    }
}
