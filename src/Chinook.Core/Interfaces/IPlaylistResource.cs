using JsonApiFramework.JsonApi;
using System.Threading.Tasks;

namespace Chinook.Core.Interfaces
{
    public interface IPlaylistResource
    {
        Task<Document> GetPlaylistResource(int resourceId);
        Task<Document> GetPlaylistResourceCollection();
    }
}