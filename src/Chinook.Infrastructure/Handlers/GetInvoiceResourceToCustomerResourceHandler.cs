using Chinook.Core.Extensions;
using Chinook.Core.Models;
using Chinook.Infrastructure.Commands;
using Chinook.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chinook.Infrastructure.Handlers
{
    public class GetInvoiceResourceToCustomerResourceHandler : IRequestHandler<GetInvoiceResourceToCustomerResourceCommand, Customer>
    {
        private readonly ChinookDbContext _chinookDbContext;

        public GetInvoiceResourceToCustomerResourceHandler(ChinookDbContext chinookDbContext)
        {
            _chinookDbContext = chinookDbContext;
        }

        public async Task<Customer> Handle(GetInvoiceResourceToCustomerResourceCommand request, CancellationToken cancellationToken)
        {
            var query = _chinookDbContext.Invoices
                .TagWithSource()
                .Where(i => i.InvoiceId == request.ResourceId)
                .Select(c => c.Customer);
            
            return await query.SingleOrDefaultAsync(cancellationToken);
        }
    }
}
