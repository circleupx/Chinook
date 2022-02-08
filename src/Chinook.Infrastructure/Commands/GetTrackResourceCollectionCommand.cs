using Chinook.Core.Models;
using MediatR;
using System.Collections.Generic;

namespace Chinook.Infrastructure.Commands
{
    public class GetTrackResourceCollectionCommand : IRequest<IEnumerable<Track>>
    {

    }
}
