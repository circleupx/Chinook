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
    public class GetEmployeeResourceCollectionHandler : IRequestHandler<GetEmployeeResourceCollectionCommand, IEnumerable<Employee>>
    {
        private readonly ChinookDbContext _chinookDbContext;

        public GetEmployeeResourceCollectionHandler(ChinookDbContext chinookDbContext)
        {
            _chinookDbContext = chinookDbContext;
        }

        public async Task<IEnumerable<Employee>> Handle(GetEmployeeResourceCollectionCommand request, CancellationToken cancellationToken)
        {
            return await _chinookDbContext.Employees.TagWithSource().ToListAsync(cancellationToken);
        }
    }
}
