using Chinook.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;

namespace Chinook.Infrastructure.Commands
{
    public class GetCustomerResourceCollectionCommand : IRequest<EntityCollectionResult<Customer>>
    {
        public GetCustomerResourceCollectionCommand()
        {
            
        }
    }
}
