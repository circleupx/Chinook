using Chinook.Core.Constants;

namespace Chinook.Web.Routes
{
    public static class ArtistRoutes
    {
        public const string ArtistResourceCollection = ArtistResourceKeyWords.Self;
        public const string ArtistResource = ArtistResourceKeyWords.Self + StandardRouteValues.ForwardSlash + StandardRouteValues.IdUriTemplate;
        public const string ArtistResourceToAlbumResourceCollection = ArtistResourceKeyWords.Self + StandardRouteValues.ForwardSlash + StandardRouteValues.IdUriTemplate + StandardRouteValues.ForwardSlash + AlbumResourceKeyWords.ToManyRelationShipKey;
    }
}