using Chinook.Core.ServiceModels;
using MediatR;
using System.Collections.Generic;

namespace Chinook.Infrastructure.Commands
{
    public class GetCustomerResourceToInvoiceResourceCollectionCommand : IRequest<IEnumerable<Invoice>>
    {
        public int ResourceId { get; }

        public GetCustomerResourceToInvoiceResourceCollectionCommand(int resourceId)
        {
            ResourceId = resourceId;
        }
    }
}
