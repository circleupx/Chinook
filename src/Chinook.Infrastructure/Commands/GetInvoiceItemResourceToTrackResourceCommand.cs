using Chinook.Core.Models;
using MediatR;

namespace Chinook.Infrastructure.Commands
{
    public class GetInvoiceItemResourceToTrackResourceCommand : IRequest<Track>
    {
        public int ResourceId { get; }

        public GetInvoiceItemResourceToTrackResourceCommand(int resourceId)
        {
            ResourceId = resourceId;
        }
    }
}
