using Chinook.Core.ServiceModels;
using MediatR;

namespace Chinook.Infrastructure.Commands
{
    public class GetInvoiceItemResourceToInvoiceResourceCommand : IRequest<Invoice>
    {
        public int ResourceId { get; }

        public GetInvoiceItemResourceToInvoiceResourceCommand(int resourceId)
        {
            ResourceId = resourceId;
        }
    }
}
