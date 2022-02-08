using Chinook.Core.Constants;

namespace Chinook.Web.Routes
{
    public static class GenreRoutes
    {
        public const string GenreResourceCollection = GenreResourceKeyWords.Self;
        public const string GenreResource = GenreResourceKeyWords.Self + StandardRouteValues.ForwardSlash + StandardRouteValues.IdUriTemplate;
        public const string GenreResourceToTrackResourceCollection = GenreResourceKeyWords.Self + StandardRouteValues.ForwardSlash + StandardRouteValues.IdUriTemplate + StandardRouteValues.ForwardSlash + TrackResourceKeyWords.ToManyRelationShipKey;
    }
}