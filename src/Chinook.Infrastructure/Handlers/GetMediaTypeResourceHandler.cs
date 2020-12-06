using Chinook.Core.ServiceModels;
using Chinook.Infrastructure.Commands;
using Chinook.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Chinook.Infrastructure.Handlers
{
    public class GetMediaTypeResourceHandler : IRequestHandler<GetMediaTypeResourceCommand, MediaType>
    {
        private readonly ChinookDbContext _chinookDbContext;

        public GetMediaTypeResourceHandler(ChinookDbContext chinookDbContext)
        {
            _chinookDbContext = chinookDbContext;
        }

        public async Task<MediaType> Handle(GetMediaTypeResourceCommand request, CancellationToken cancellationToken)
        {
            return await _chinookDbContext.MediaTypes.FirstOrDefaultAsync(c => c.MediaTypeId == request.ResourceId, cancellationToken);
        }
    }
}
