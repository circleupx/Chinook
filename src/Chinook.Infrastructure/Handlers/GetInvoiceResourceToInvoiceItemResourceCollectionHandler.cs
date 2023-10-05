using Chinook.Core.Extensions;
using Chinook.Core.Models;
using Chinook.Infrastructure.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chinook.Infrastructure.Handlers
{
    public class GetInvoiceResourceToInvoiceItemResourceCollectionHandler : IRequestHandler<GetInvoiceResourceToInvoiceItemResourceCollectionCommand, IEnumerable<InvoiceItem>>
    {
        private readonly ChinookDbContext _chinookDbContext;

        public GetInvoiceResourceToInvoiceItemResourceCollectionHandler(ChinookDbContext chinookDbContext)
        {
            _chinookDbContext = chinookDbContext;
        }

        public async Task<IEnumerable<InvoiceItem>> Handle(GetInvoiceResourceToInvoiceItemResourceCollectionCommand request, CancellationToken cancellationToken)
        {
            var query = _chinookDbContext.Invoices
                .TagWithSource()
                .Where(i => i.InvoiceId == request.ResourceId)
                .SelectMany(iItem => iItem.InvoiceItems);

            return await query.ToListAsync(cancellationToken);
        }
    }
}
