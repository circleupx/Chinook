using Chinook.Core.Constants;

namespace Chinook.Web.Routes
{
    public static class InvoiceRoutes
    {
        public const string InvoiceResourceCollection = InvoiceResourceKeyWords.Self;
        public const string InvoiceResource = InvoiceResourceKeyWords.Self + StandardRouteValues.ForwardSlash + StandardRouteValues.IdUriTemplate;
        public const string InvoiceResourceToCustomerResource = InvoiceResourceKeyWords.Self + StandardRouteValues.ForwardSlash + StandardRouteValues.IdUriTemplate + StandardRouteValues.ForwardSlash + CustomerResourceKeyWords.ToOneRelationshipKey;
        public const string InvoiceResourceToInvoiceItemResourceCollection = InvoiceResourceKeyWords.Self + StandardRouteValues.ForwardSlash + StandardRouteValues.IdUriTemplate + StandardRouteValues.ForwardSlash + InvoiceItemResourceKeyWords.ToManyRelationShipKey;
    }
}