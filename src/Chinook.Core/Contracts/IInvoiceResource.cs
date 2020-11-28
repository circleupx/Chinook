using JsonApiFramework.JsonApi;
using System.Threading.Tasks;

namespace Chinook.Web.Resources
{
    public interface IInvoiceResource
    {
        Task<Document> GetInvoiceResource(int resourceId);
        Task<Document> GetInvoiceResourceCollection();
    }
}