using JsonApiFramework.JsonApi;
using System.Threading.Tasks;

namespace Chinook.Core.Interfaces
{
    public interface IInvoiceItemResource
    {
        Task<Document> GetInvoiceItemResource(int resourceId);
        Task<Document> GetInvoiceItemResourceCollection();
        Task<Document> GetInvoiceItemResourceToInvoiceResource(int resourceId);
        Task<Document> GetInvoiceItemResourceToTrackResource(int resourceId);
    }
}