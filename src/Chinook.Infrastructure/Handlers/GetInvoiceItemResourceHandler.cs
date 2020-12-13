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
    public class GetInvoiceItemResourceHandler : IRequestHandler<GetInvoiceItemResourceCommand, InvoiceItem>
    {
        private readonly ChinookDbContext _chinookDbContext;

        public GetInvoiceItemResourceHandler(ChinookDbContext chinookDbContext)
        {
            _chinookDbContext = chinookDbContext;
        }

        public async Task<InvoiceItem> Handle(GetInvoiceItemResourceCommand request, CancellationToken cancellationToken)
        {
            return await _chinookDbContext.InvoiceItems.TagWithSource().FirstOrDefaultAsync(c => c.InvoiceLineId == request.ResourceId, cancellationToken);
        }
    }
}
