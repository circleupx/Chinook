using Chinook.Core;
using Chinook.Core.Models;
using Chinook.Infrastructure.Commands;
using Chinook.Infrastructure.Database;
using JsonApiFramework;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Chinook.Infrastructure.Handlers
{
    public class CreateCustomerResourceHandler : IRequestHandler<CreateCustomerResourceCommand, Customer>
    {
        private readonly ChinookDbContext _chinookDbContext;

        public CreateCustomerResourceHandler(ChinookDbContext chinookDbContext)
        {
            _chinookDbContext = chinookDbContext;
        }

        public async Task<Customer> Handle(CreateCustomerResourceCommand request, CancellationToken cancellationToken)
        {
            var jsonApiDocumentContext = new ChinookJsonApiDocumentContext(request.Document);
            var resource = jsonApiDocumentContext.GetResource<Customer>();

            _chinookDbContext.Customers
                .Add(resource);
                
            await _chinookDbContext
                .SaveChangesAsync(cancellationToken);

            return resource;
        }
    }
}
