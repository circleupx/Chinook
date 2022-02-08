using Chinook.Core.Models;
using JsonApiFramework.JsonApi;
using MediatR;

namespace Chinook.Infrastructure.Commands
{
    public class CreateCustomerResourceCommand : IRequest<Customer>
    {
        public CreateCustomerResourceCommand(Document document)
        {
            Document = document;
        }

        public Document Document { get; }
    }
}
