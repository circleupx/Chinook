using Chinook.Core.Constants;

namespace Chinook.Web.Routes
{
    public static class PlaylistRoutes
    {
        public const string PlaylistResourceCollection = PlaylistResourceKeyWords.Self;
        public const string PlaylistResource = PlaylistResourceKeyWords.Self + StandardRouteValues.ForwardSlash + StandardRouteValues.IdUriTemplate;
    }
}