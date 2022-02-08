using Chinook.Core.Models;
using MediatR;

namespace Chinook.Infrastructure.Commands
{
    public class GetCustomerResourceCommand : IRequest<Customer>
    {
        public int ResourceId { get; }

        public GetCustomerResourceCommand(int resourceId)
        {
            ResourceId = resourceId;
        }
    }
}