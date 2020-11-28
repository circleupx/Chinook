using Chinook.Core.ServiceModels;
using MediatR;

namespace Chinook.Infrastructure.Commands
{
    public class GetArtistResourceCommand : IRequest<Artist>
    {
        public int ResourceId { get; }

        public GetArtistResourceCommand(int resourceId)
        {
            ResourceId = resourceId;
        }
    }
}
