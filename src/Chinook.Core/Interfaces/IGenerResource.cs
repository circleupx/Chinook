using JsonApiFramework.JsonApi;
using System.Threading.Tasks;

namespace Chinook.Core.Interfaces
{
    public interface IGenerResource
    {
        Task<Document> GetGenreResource(int resourceId);
        Task<Document> GetGenreResourceCollection();
        Task<Document> GetGenreResourceToTrackResourceCollection(int resourceId);
    }
}