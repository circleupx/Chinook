using JsonApiFramework.JsonApi;
using System.Threading.Tasks;

namespace Chinook.Core.Interfaces
{
    public interface IArtistResource
    {
        Task<Document> GetArtistResource(int resourceId);
        Task<Document> GetArtistResourceCollection();
        Task<Document> GetArtistResourceToAlbumResourceCollection(int resourceId);
    }
}