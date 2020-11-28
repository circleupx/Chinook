using Chinook.Core.ServiceModels;
using MediatR;
using System.Collections.Generic;

namespace Chinook.Infrastructure.Commands
{
    public class GetEmployeeResourceCollectionCommand : IRequest<IEnumerable<Employee>>
    {

    }
}
