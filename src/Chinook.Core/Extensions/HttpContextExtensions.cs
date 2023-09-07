using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using System;

namespace Chinook.Core.Extensions
{
    public static class HttpContextExtensions
    {
        public static Uri GetRequestUri(this HttpContext httpContext)
        {
            var currentRequestUri = httpContext.Request.GetDisplayUrl();
            return new Uri(currentRequestUri);
        }
    }
}
