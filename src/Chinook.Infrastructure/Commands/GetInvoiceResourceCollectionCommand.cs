using Chinook.Core;
using Chinook.Core.Models;
using MediatR;
using System.Collections.Generic;

namespace Chinook.Infrastructure.Commands
{
    public class GetInvoiceResourceCollectionCommand : IRequest<IEnumerable<Invoice>>
    {
        internal readonly ResoureQuerySpecification querySpecification;

        public GetInvoiceResourceCollectionCommand(ResoureQuerySpecification resoureQuerySpecification)
        {
            this.querySpecification = resoureQuerySpecification;
        }
    }
}
