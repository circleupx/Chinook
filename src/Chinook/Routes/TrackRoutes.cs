using Chinook.Core.Constants;

namespace Chinook.Web.Routes
{
    public static class TrackRoutes
    {
        public const string PlaylistResourceCollection = TrackResourceKeyWords.Self;
        public const string PlaylistResource = TrackResourceKeyWords.Self + StandardRouteValues.ForwardSlash + StandardRouteValues.IdUriTemplate;
    }
}