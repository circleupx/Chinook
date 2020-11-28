using JsonApiFramework.JsonApi;
using System.Threading.Tasks;

namespace Chinook.Web.Resources
{
    public interface IArtistResource
    {
        Task<Document> GetArtistResource(int resourceId);
        Task<Document> GetArtistResourceCollection();
    }
}