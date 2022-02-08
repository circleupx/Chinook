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
    public class GetInvoiceItemResourceToInvoiceResourceHandler : IRequestHandler<GetInvoiceItemResourceToInvoiceResourceCommand, Invoice>
    {
        private readonly ChinookDbContext _chinookDbContext;

        public GetInvoiceItemResourceToInvoiceResourceHandler(ChinookDbContext chinookDbContext)
        {
            _chinookDbContext = chinookDbContext;
        }

        public async Task<Invoice> Handle(GetInvoiceItemResourceToInvoiceResourceCommand request, CancellationToken cancellationToken)
        {
            var query = _chinookDbContext.InvoiceItems
                .TagWithSource()
                .Where(a => a.InvoiceLineId == request.ResourceId)
                .Select(d => d.Invoice);

            return await query.SingleOrDefaultAsync(cancellationToken);
        }
    }
}
