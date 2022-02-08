using Chinook.Core.Extensions;
using Chinook.Core.Models;
using Chinook.Infrastructure.Commands;
using Chinook.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chinook.Infrastructure.Handlers
{
    public class GetCustomerResourceToInvoiceResourceCollectionHandler : IRequestHandler<GetCustomerResourceToInvoiceResourceCollectionCommand, IEnumerable<Invoice>>
    {
        private readonly ChinookDbContext _chinookDbContext;

        public GetCustomerResourceToInvoiceResourceCollectionHandler(ChinookDbContext chinookDbContext)
        {
            _chinookDbContext = chinookDbContext;
        }

        public async Task<IEnumerable<Invoice>> Handle(GetCustomerResourceToInvoiceResourceCollectionCommand request, CancellationToken cancellationToken)
        {
            var query = _chinookDbContext.Customers
                .TagWithSource()
                .Where(c => c.CustomerId == request.ResourceId)
                .SelectMany(i => i.Invoices);

            return await query.ToListAsync(cancellationToken);
        }
    }
}
