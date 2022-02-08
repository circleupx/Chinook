using JsonApiFramework.JsonApi;
using System.Threading.Tasks;

namespace Chinook.Core.Interfaces
{
    public interface IInvoiceResource
    {
        Task<Document> GetInvoiceResource(int resourceId);
        Task<Document> GetInvoiceResourceCollection();
        Task<Document> GetInvoiceResourceToCustomerResource(int resourceId);
        Task<Document> GetInvoiceResourceToInvoiceItemResourceCollection(int resourceId);
    }
}