using JsonApiFramework.JsonApi;
using System.Threading.Tasks;

namespace Chinook.Web.Resources
{
    public interface ITrackResource
    {
        Task<Document> GetTrackResource(int resourceId);
        Task<Document> GetTrackResourceCollection();
    }
}