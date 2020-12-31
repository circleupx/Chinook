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
    public class GetTrackResourceToInvoiceItemResourceCollectionHandler : IRequestHandler<GetTackResourceToInvoiceItemResourceCollectionCommand, IEnumerable<InvoiceItem>>
    {
        private readonly ChinookDbContext _chinookDbContext;

        public GetTrackResourceToInvoiceItemResourceCollectionHandler(ChinookDbContext chinookDbContext)
        {
            _chinookDbContext = chinookDbContext;
        }

        public async Task<IEnumerable<InvoiceItem>> Handle(GetTackResourceToInvoiceItemResourceCollectionCommand request, CancellationToken cancellationToken)
        {
            var query = _chinookDbContext.Tracks
                .TagWithSource()
                .Where(t => t.TrackId == request.ResourceId)
                .SelectMany(iItem => iItem.InvoiceItems);

            return await query.ToListAsync(cancellationToken);
        }
    }
}
