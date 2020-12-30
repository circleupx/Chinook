using Chinook.Core.Constants;

namespace Chinook.Web.Routes
{
    public static class TrackRoutes
    {
        public const string TrackResourceCollection = TrackResourceKeyWords.Self;
        public const string TrackResource = TrackResourceKeyWords.Self + StandardRouteValues.ForwardSlash + StandardRouteValues.IdUriTemplate;
        public const string TrackResourceToAlbumResource = TrackResourceKeyWords.Self + StandardRouteValues.ForwardSlash + StandardRouteValues.IdUriTemplate + StandardRouteValues.ForwardSlash + AlbumResourceKeyWords.ToOneRelationshipKey;
    }
}