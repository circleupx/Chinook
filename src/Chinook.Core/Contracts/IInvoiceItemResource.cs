using JsonApiFramework.JsonApi;
using System.Threading.Tasks;

namespace Chinook.Web.Resources
{
    public interface IInvoiceItemResource
    {
        Task<Document> GetInvoiceItemResource(int resourceId);
        Task<Document> GetInvoiceItemResourceCollection();
        Task<Document> GetInvoiceItemResourceToInvoiceResource(int resourceId);
        Task<Document> GetInvoiceItemResourceToTrackResource(int resourceId);
    }
}