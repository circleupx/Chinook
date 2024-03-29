﻿using Chinook.Core.Models;
using MediatR;

namespace Chinook.Infrastructure.Commands
{
    public class GetTackResourceToGenreResourceCommand : IRequest<Genre>
    {
        public int ResourceId { get; }

        public GetTackResourceToGenreResourceCommand(int resourceId)
        {
            ResourceId = resourceId;
        }
    }
}
