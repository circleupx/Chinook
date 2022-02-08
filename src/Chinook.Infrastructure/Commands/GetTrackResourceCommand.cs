using Chinook.Core.Models;
using MediatR;

namespace Chinook.Infrastructure.Commands
{
    public class GetTrackResourceCommand : IRequest<Track>
    {
        public int ResourceId { get; }

        public GetTrackResourceCommand(int resourceId)
        {
            ResourceId = resourceId;
        }
    }
}
