using Chinook.Core.Constants;

namespace Chinook.Web.Routes
{
    public static class InvoiceRoutes
    {
        public const string InvoiceResourceCollection = InvoiceResourceKeyWords.Self;
        public const string InvoiceResource = InvoiceResourceKeyWords.Self + StandardRouteValues.ForwardSlash + StandardRouteValues.IdUriTemplate;
    }
}