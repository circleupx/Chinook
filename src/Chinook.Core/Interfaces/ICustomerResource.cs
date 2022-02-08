using JsonApiFramework.JsonApi;
using System.Threading.Tasks;

namespace Chinook.Core.Interfaces
{
    public interface ICustomerResource
    {
        Task<Document> GetCustomerResource(int resourceId);
        Task<Document> GetCustomerResourceCollection();
        Task<Document> GetCustomerResourceToInvoiceResourceCollection(int resourceId);
        Task<Document> CreateCustomerResource(Document jsonApiDocument);
    }
}