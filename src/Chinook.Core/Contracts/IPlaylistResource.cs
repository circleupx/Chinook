using JsonApiFramework.JsonApi;
using System.Threading.Tasks;

namespace Chinook.Web.Resources
{
    public interface IPlaylistResource
    {
        Task<Document> GetPlaylistResource(int resourceId);
        Task<Document> GetPlaylistResourceCollection();
    }
}