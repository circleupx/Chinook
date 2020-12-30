using JsonApiFramework.JsonApi;
using System.Threading.Tasks;

namespace Chinook.Web.Resources
{
    public interface ITrackResource
    {
        Task<Document> GetTrackResourceCollection();
        Task<Document> GetTrackResourceToAlbumResource(int resourceId);
        Task<Document> GetTrackResource(int resourceId);
    }
}