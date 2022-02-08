using Chinook.Core.Extensions;
using Chinook.Core.Models;
using Chinook.Infrastructure.Commands;
using Chinook.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
            return await _chinookDbContext.Invoices
                .TagWithSource()
                .ToListAsync(cancellationToken);
        }
    }
}
