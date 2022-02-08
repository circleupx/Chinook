using Chinook.Core.Models;
using MediatR;
using System.Collections.Generic;

namespace Chinook.Infrastructure.Commands
{
    public class GetInvoiceResourceToInvoiceItemResourceCollectionCommand : IRequest<IEnumerable<InvoiceItem>>
    {
        public int ResourceId { get; }

        public GetInvoiceResourceToInvoiceItemResourceCollectionCommand(int resourceId)
        {
            ResourceId = resourceId;
        }
    }
}
