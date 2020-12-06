using JsonApiFramework.JsonApi;
using System.Threading.Tasks;

namespace Chinook.Web.Resources
{
    public interface IMediaTypeResource
    {
        Task<Document> GetMediaTypeResource(int resourceId);
        Task<Document> GetMediaTypeResourceCollection();
    }
}