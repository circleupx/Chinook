using Chinook.Core.Models;
using MediatR;

namespace Chinook.Infrastructure.Commands
{
    public class GetGenreResourceCommand : IRequest<Genre>
    {
        public int ResourceId { get; }

        public GetGenreResourceCommand(int resourceId)
        {
            ResourceId = resourceId;
        }
    }
}
