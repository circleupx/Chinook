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
    public class GetCustomerResourceCollectionHandler : IRequestHandler<GetCustomerResourceCollectionCommand, IEnumerable<Customer>>
    {
        private readonly ChinookDbContext _chinookDbContext;

        public GetCustomerResourceCollectionHandler(ChinookDbContext chinookDbContext )
        {
            _chinookDbContext = chinookDbContext;
        }

        public async Task<IEnumerable<Customer>> Handle(GetCustomerResourceCollectionCommand request, CancellationToken cancellationToken)
        {
            return await _chinookDbContext.Customers.TagWithSource().ToListAsync(cancellationToken);
        }
    }
}
