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
    public class GetInvoiceItemResourceToTrackResourceHandler : IRequestHandler<GetInvoiceItemResourceToTrackResourceCommand, Track>
    {
        private readonly ChinookDbContext _chinookDbContext;

        public GetInvoiceItemResourceToTrackResourceHandler(ChinookDbContext chinookDbContext)
        {
            _chinookDbContext = chinookDbContext;
        }

        public async Task<Track> Handle(GetInvoiceItemResourceToTrackResourceCommand request, CancellationToken cancellationToken)
        {
            var query = _chinookDbContext.InvoiceItems
                .TagWithSource()
                .Where(a => a.InvoiceLineId == request.ResourceId)
                .Select(d => d.Track);

            return await query.SingleOrDefaultAsync(cancellationToken);
        }
    }
}
