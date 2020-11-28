using JsonApiFramework.JsonApi;
using System.Threading.Tasks;

namespace Chinook.Web.Resources
{
    public interface IGenerResource
    {
        Task<Document> GetGenreResource(int resourceId);
        Task<Document> GetGenreResourceCollection();
    }
}