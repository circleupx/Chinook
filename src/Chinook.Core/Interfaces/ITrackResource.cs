using JsonApiFramework.JsonApi;
using System.Threading.Tasks;

namespace Chinook.Core.Interfaces
{
    public interface ITrackResource
    {
        Task<Document> GetTrackResourceCollection();
        Task<Document> GetTrackResourceToAlbumResource(int resourceId);
        Task<Document> GetTrackResourceToGenreResource(int resourceId);
        Task<Document> GetTrackResourceToMediaTypeResource(int resourceId);
        Task<Document> GetTrackResourceToInvoiceItemResourceCollection(int resourceId);
        Task<Document> GetTrackResourceToPlaylistTrackResourceCollection(int resourceId);
        Task<Document> GetTrackResource(int resourceId);
    }
}