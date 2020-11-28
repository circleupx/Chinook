using JsonApiFramework.JsonApi;
using System.Threading.Tasks;

namespace Chinook.Web.Resources
{
    public interface IEmployeeResource
    {
        Task<Document> GetEmployeeResource(int resourceId);
        Task<Document> GetEmployeeResourceCollection();
    }
}