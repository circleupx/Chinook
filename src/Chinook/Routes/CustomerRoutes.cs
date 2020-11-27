using Chinook.Core.Constants;

namespace Chinook.Web.Routes
{
    public static class CustomerRoutes
    {
        public const string CustomerResourceCollection = CustomerResourceKeyWords.Self;
        public const string CustomerResource = CustomerResourceKeyWords.Self + StandardUriValues.ForwardSlash + StandardUriValues.IdUriTemplate;
    }
}