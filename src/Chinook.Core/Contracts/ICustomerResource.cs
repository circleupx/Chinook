using JsonApiFramework.JsonApi;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Chinook.Web.Resources
{
    public interface ICustomerResource
    {
        Task<Document> GetCustomerResource(int resourceId);
        Task<Document> GetCustomerResourceCollection();
        Task<Document> GetCustomerResourceToInvoiceResourceCollection(int resourceId);
    }
}