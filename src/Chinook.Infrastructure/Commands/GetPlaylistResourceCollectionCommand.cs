﻿using Chinook.Core.ServiceModels;
using MediatR;
using System.Collections.Generic;

namespace Chinook.Infrastructure.Commands
{
    public class GetPlaylistResourceCollectionCommand : IRequest<IEnumerable<Playlist>>
    {

    }
}
