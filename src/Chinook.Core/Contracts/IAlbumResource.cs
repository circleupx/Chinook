using JsonApiFramework.JsonApi;
using System.Threading.Tasks;

namespace Chinook.Web.Resources
{
    public interface IAlbumResource
    {
        Task<Document> GetAlbumResource(int resourceId);
        Task<Document> GetAlbumResourceCollection();
        Task<Document> GetAlbumResourceToArtistResource(int resourceId);
    }
}