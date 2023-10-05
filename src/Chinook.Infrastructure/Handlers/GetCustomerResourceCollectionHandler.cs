// using Chinook.Core.Extensions;
// using Chinook.Core.Models;
// using Chinook.Infrastructure.Commands;
// using MediatR;
// using Microsoft.EntityFrameworkCore;
// using System.Linq;
// using System.Threading;
// using System.Threading.Tasks;

// namespace Chinook.Infrastructure.Handlers
// {
//     public class GetCustomerResourceCollectionHandler : IRequestHandler<GetCustomerResourceCollectionCommand, EntityCollectionResult<Customer>>
//     {
//         private readonly ChinookDbContext _chinookDbContext;
//         //private readonly CustomerQuerySpecification _customerQuerySpecification;

//         public GetCustomerResourceCollectionHandler(ChinookDbContext chinookDbContext, CustomerQuerySpecification customerQuerySpecification)
//         {
//             _chinookDbContext = chinookDbContext;
//             //_customerQuerySpecification = customerQuerySpecification;
//         }

//         // public async Task<EntityCollectionResult<Customer>> Handle(GetCustomerResourceCollectionCommand request, CancellationToken cancellationToken)
//         // {
//         //     var count = await _chinookDbContext.Customers.CountAsync(_customerQuerySpecification.FilterExpression);
//         //     var value = await _chinookDbContext.Customers
//         //         .TagWithSource()
//         //         .Skip(_customerQuerySpecification.Skip)
//         //         .Take(_customerQuerySpecification.Take)
//         //         .ToListAsync(cancellationToken);

//         //     return new EntityCollectionResult<Customer>(count, value);
//         // }
//     }
// }
