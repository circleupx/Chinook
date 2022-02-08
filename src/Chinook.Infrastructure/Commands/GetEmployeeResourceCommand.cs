using Chinook.Core.Models;
using MediatR;

namespace Chinook.Infrastructure.Commands
{
    public class GetEmployeeResourceCommand : IRequest<Employee>
    {
        public int ResourceId { get; }

        public GetEmployeeResourceCommand(int resourceId)
        {
            ResourceId = resourceId;
        }
    }
}
