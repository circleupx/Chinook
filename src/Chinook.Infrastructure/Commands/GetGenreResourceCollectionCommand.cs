using Chinook.Core.Models;
using MediatR;
using System.Collections.Generic;

namespace Chinook.Infrastructure.Commands
{
    public class GetGenreResourceCollectionCommand : IRequest<IEnumerable<Genre>>
    {

    }
}
