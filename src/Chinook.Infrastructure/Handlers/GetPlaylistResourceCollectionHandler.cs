﻿using Chinook.Core.Extensions;
using Chinook.Core.Models;
using Chinook.Infrastructure.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Chinook.Infrastructure.Handlers
{
    public class GetPlaylistResourceCollectionHandler : IRequestHandler<GetPlaylistResourceCollectionCommand, IEnumerable<Playlist>>
    {
        private readonly ChinookDbContext _chinookDbContext;

        public GetPlaylistResourceCollectionHandler(ChinookDbContext chinookDbContext)
        {
            _chinookDbContext = chinookDbContext;
        }

        public async Task<IEnumerable<Playlist>> Handle(GetPlaylistResourceCollectionCommand request, CancellationToken cancellationToken)
        {
            return await _chinookDbContext.Playlists
                .TagWithSource()
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
