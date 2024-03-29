﻿using Chinook.Core.Models;
using MediatR;

namespace Chinook.Infrastructure.Commands
{
    public class GetInvoiceResourceCommand : IRequest<Invoice>
    {
        public int ResourceId { get; }

        public GetInvoiceResourceCommand(int resourceId)
        {
            ResourceId = resourceId;
        }
    }
}
