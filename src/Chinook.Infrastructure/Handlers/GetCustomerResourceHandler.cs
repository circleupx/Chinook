using Chinook.Core.Extensions;
using Chinook.Core.ServiceModels;
using Chinook.Infrastructure.Commands;
using Chinook.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Chinook.Infrastructure.Handlers
{
    public class GetCustomerResourceHandler : IRequestHandler<GetCustomerResourceCommand, Customer>
    {
        private readonly ChinookDbContext _chinookDbContext;

        public GetCustomerResourceHandler(ChinookDbContext chinookDbContext)
        {
            _chinookDbContext = chinookDbContext;
        }

        public async Task<Customer> Handle(GetCustomerResourceCommand request, CancellationToken cancellationToken)
        {
            return await _chinookDbContext.Customers
                .TagWithSource()
                .FirstOrDefaultAsync(c=>c.CustomerId == request.ResourceId, cancellationToken);
        }
    }
}
