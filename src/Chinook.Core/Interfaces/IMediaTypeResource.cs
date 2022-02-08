using JsonApiFramework.JsonApi;
using System.Threading.Tasks;

namespace Chinook.Core.Interfaces
{
    public interface IMediaTypeResource
    {
        Task<Document> GetMediaTypeResource(int resourceId);
        Task<Document> GetMediaTypeResourceCollection();
        Task<Document> GetMediaTypeResourceToTrackResourceCollection(int resourceId);
    }
}