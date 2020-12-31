using Chinook.Core.ServiceModels;
using MediatR;
using System.Collections.Generic;

namespace Chinook.Infrastructure.Commands
{
    public class GetTackResourceToInvoiceItemResourceCollectionCommand : IRequest<IEnumerable<InvoiceItem>>
    {
        public int ResourceId { get; }

        public GetTackResourceToInvoiceItemResourceCollectionCommand(int resourceId)
        {
            ResourceId = resourceId;
        }
    }
}
