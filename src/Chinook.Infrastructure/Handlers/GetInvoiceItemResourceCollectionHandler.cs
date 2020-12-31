using Chinook.Core.Extensions;
using Chinook.Core.ServiceModels;
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
    public class GetInvoiceItemResourceCollectionHandler : IRequestHandler<GetInvoiceItemResourceCollectionCommand, IEnumerable<InvoiceItem>>
    {
        private readonly ChinookDbContext _chinookDbContext;

        public GetInvoiceItemResourceCollectionHandler(ChinookDbContext chinookDbContext)
        {
            _chinookDbContext = chinookDbContext;
        }

        public async Task<IEnumerable<InvoiceItem>> Handle(GetInvoiceItemResourceCollectionCommand request, CancellationToken cancellationToken)
        {
            // Limit the amount of data return until pagination is implemented.
            return await _chinookDbContext.InvoiceItems
                .TagWithSource()
                .Skip(0)
                .Take(100)
                .ToListAsync(cancellationToken);
        }
    }
}
