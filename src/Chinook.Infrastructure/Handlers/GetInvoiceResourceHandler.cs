using Chinook.Core.Extensions;
using Chinook.Core.Models;
using Chinook.Infrastructure.Commands;
using Chinook.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Chinook.Infrastructure.Handlers
{
    public class GetInvoiceResourceHandler : IRequestHandler<GetInvoiceResourceCommand, Invoice>
    {
        private readonly ChinookDbContext _chinookDbContext;

        public GetInvoiceResourceHandler(ChinookDbContext chinookDbContext)
        {
            _chinookDbContext = chinookDbContext;
        }

        public async Task<Invoice> Handle(GetInvoiceResourceCommand request, CancellationToken cancellationToken)
        {
            return await _chinookDbContext.Invoices
                .TagWithSource()
                .FirstOrDefaultAsync(c => c.InvoiceId == request.ResourceId, cancellationToken);
        }
    }
}
