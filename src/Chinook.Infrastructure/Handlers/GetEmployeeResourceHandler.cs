using Chinook.Core.ServiceModels;
using Chinook.Infrastructure.Commands;
using Chinook.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Chinook.Infrastructure.Handlers
{
    public class GetEmployeeResourceHandler : IRequestHandler<GetEmployeeResourceCommand, Employee>
    {
        private readonly ChinookDbContext _chinookDbContext;

        public GetEmployeeResourceHandler(ChinookDbContext chinookDbContext)
        {
            _chinookDbContext = chinookDbContext;
        }

        public async Task<Employee> Handle(GetEmployeeResourceCommand request, CancellationToken cancellationToken)
        {
            return await _chinookDbContext.Employees.FirstOrDefaultAsync(c => c.EmployeeId == request.ResourceId, cancellationToken);
        }
    }
}
