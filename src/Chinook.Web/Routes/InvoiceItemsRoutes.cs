using Chinook.Core.Constants;

namespace Chinook.Web.Routes
{
    public static class InvoiceItemsRoutes
    {
        public const string InvoiceItemsResourceCollection = InvoiceItemResourceKeyWords.Self;
        public const string InvoiceItemsResource = InvoiceItemResourceKeyWords.Self + StandardRouteValues.ForwardSlash + StandardRouteValues.IdUriTemplate;
        public const string InvoiceItemResourceToInvoiceResource = InvoiceItemResourceKeyWords.Self + StandardRouteValues.ForwardSlash + StandardRouteValues.IdUriTemplate + StandardRouteValues.ForwardSlash + InvoiceResourceKeyWords.ToOneRelationshipKey;
        public const string InvoiceItemResourceToTrackResource = InvoiceItemResourceKeyWords.Self + StandardRouteValues.ForwardSlash + StandardRouteValues.IdUriTemplate + StandardRouteValues.ForwardSlash + TrackResourceKeyWords.ToOneRelationshipKey;
    }
}