using Chinook.Core.Extensions;
using Chinook.Core.Models;
using Chinook.Infrastructure.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Chinook.Infrastructure.Handlers
{
    public class GetInvoiceResourceCollectionHandler : IRequestHandler<GetInvoiceResourceCollectionCommand, IEnumerable<Invoice>>
    {
        private readonly ChinookDbContext _chinookDbContext;

        public GetInvoiceResourceCollectionHandler(ChinookDbContext chinookDbContext)
        {
            _chinookDbContext = chinookDbContext;
        }

        public async Task<IEnumerable<Invoice>> Handle(GetInvoiceResourceCollectionCommand request, CancellationToken cancellationToken)
        {
            Expression<Func<Invoice, bool>> invoiceFilter = request.querySpecification.GetFilter<Invoice>(nameof(Invoice));
            Expression<Func<Customer, bool>> customerFilter = request.querySpecification.GetFilter<Customer>(nameof(Customer));

            var invoiceQuery = _chinookDbContext.Invoices.Where(invoiceFilter);
            var customerQuery = _chinookDbContext.Customers.Where(customerFilter);

            var query =
                from fi in invoiceQuery
                join fc in customerQuery on fi.CustomerId equals fc.CustomerId
                select fi;

            var result = await query
                .TagWithSource()
                .ToListAsync();

            return result;
        }
    }
}
