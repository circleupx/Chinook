using Chinook.Core.Constants;

namespace Chinook.Web.Routes
{
    public static class TrackRoutes
    {
        public const string TrackResourceCollection = TrackResourceKeyWords.Self;
        public const string TrackResource = TrackResourceKeyWords.Self + StandardRouteValues.ForwardSlash + StandardRouteValues.IdUriTemplate;
        public const string TrackResourceToAlbumResource = TrackResourceKeyWords.Self + StandardRouteValues.ForwardSlash + StandardRouteValues.IdUriTemplate + StandardRouteValues.ForwardSlash + AlbumResourceKeyWords.ToOneRelationshipKey;
        public const string TrackResourceToGenreResource = TrackResourceKeyWords.Self + StandardRouteValues.ForwardSlash + StandardRouteValues.IdUriTemplate + StandardRouteValues.ForwardSlash + GenreResourceKeyWords.ToOneRelationshipKey;
        public const string TrackResourceToMediaTypeResource = TrackResourceKeyWords.Self + StandardRouteValues.ForwardSlash + StandardRouteValues.IdUriTemplate + StandardRouteValues.ForwardSlash + MediaTypeResourceKeyWords.ToOneRelationshipKey;
        public const string TrackResourceToInvoiceItemResourceCollection = TrackResourceKeyWords.Self + StandardRouteValues.ForwardSlash + StandardRouteValues.IdUriTemplate + StandardRouteValues.ForwardSlash + InvoiceItemResourceKeyWords.ToManyRelationShipKey;
        public const string TrackResourceToPlaylistTrackResourceCollection = TrackResourceKeyWords.Self + StandardRouteValues.ForwardSlash + StandardRouteValues.IdUriTemplate + StandardRouteValues.ForwardSlash + PlaylistTrackResourceKeyWords.ToManyRelationShipKey;
    }
}