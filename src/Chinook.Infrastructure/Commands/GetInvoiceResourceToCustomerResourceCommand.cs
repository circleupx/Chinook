using Chinook.Core.ServiceModels;
using MediatR;

namespace Chinook.Infrastructure.Commands
{
    public class GetInvoiceResourceToCustomerResourceCommand : IRequest<Customer>
    {
        public int ResourceId { get; }

        public GetInvoiceResourceToCustomerResourceCommand(int resourceId)
        {
            ResourceId = resourceId;
        }
    }
}
