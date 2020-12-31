using Chinook.Core.Extensions;
using Chinook.Core.ServiceModels;
using Chinook.Infrastructure.Commands;
using Chinook.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Chinook.Infrastructure.Handlers
{
    public class GetMediaTypeResourceCollectionHandler : IRequestHandler<GetMediaTypeResourceCollectionCommand, IEnumerable<MediaType>>
    {
        private readonly ChinookDbContext _chinookDbContext;

        public GetMediaTypeResourceCollectionHandler(ChinookDbContext chinookDbContext)
        {
            _chinookDbContext = chinookDbContext;
        }

        public async Task<IEnumerable<MediaType>> Handle(GetMediaTypeResourceCollectionCommand request, CancellationToken cancellationToken)
        {
            return await _chinookDbContext.MediaTypes
                .TagWithSource()
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
