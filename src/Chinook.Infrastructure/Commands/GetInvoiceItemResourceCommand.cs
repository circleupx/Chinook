﻿using Chinook.Core.Models;
using MediatR;

namespace Chinook.Infrastructure.Commands
{
    public class GetInvoiceItemResourceCommand : IRequest<InvoiceItem>
    {
        public int ResourceId { get; }

        public GetInvoiceItemResourceCommand(int resourceId)
        {
            ResourceId = resourceId;
        }
    }
}
