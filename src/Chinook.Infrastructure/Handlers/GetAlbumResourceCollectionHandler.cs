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
    public class GetAlbumResourceCollectionHandler : IRequestHandler<GetAlbumResourceCollectionCommand, IEnumerable<Album>>
    {
        private readonly ChinookDbContext _chinookDbContext;

        public GetAlbumResourceCollectionHandler(ChinookDbContext chinookDbContext)
        {
            _chinookDbContext = chinookDbContext;
        }

        public async Task<IEnumerable<Album>> Handle(GetAlbumResourceCollectionCommand request, CancellationToken cancellationToken)
        {
            Expression<Func<Album, bool>> filterExpression = request.querySpecification.GetFilter<Invoice>(nameof(Album));
 
            return await _chinookDbContext.Albums
                .TagWithSource()
                .Where(filterExpression)
                .ToListAsync(cancellationToken);
        }
    }
}
