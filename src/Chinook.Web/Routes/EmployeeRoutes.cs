using Chinook.Core.Constants;

namespace Chinook.Web.Routes
{
    public static class EmployeeRoutes
    {
        public const string EmployeeResourceCollection = EmployeeResourceKeyWords.Self;
        public const string EmployeeResource = EmployeeResourceKeyWords.Self + StandardRouteValues.ForwardSlash + StandardRouteValues.IdUriTemplate;
    }
}