using JsonApiFramework.JsonApi;
using System.Threading.Tasks;

namespace Chinook.Core.Interfaces
{
    public interface IEmployeeResource
    {
        Task<Document> GetEmployeeResource(int resourceId);
        Task<Document> GetEmployeeResourceCollection();
    }
}