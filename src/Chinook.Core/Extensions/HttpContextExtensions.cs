using Microsoft.AspNetCore.Http;
using System;

namespace Chinook.Core.Extensions
{
    public static class HttpContextExtensions
    {
        public static Uri GetCurrentRequestUri(this HttpContext httpContext)
        {
            var currentRequest = httpContext.Request;

            var currentRequestUriBuilder = new UriBuilder
            {
                Scheme = currentRequest.Scheme,
                Host = currentRequest.Host.Host,
                Port = currentRequest.Host.Port.GetValueOrDefault(),
                Path = currentRequest.Path.Value
            };

            var currentRequestUri = currentRequestUriBuilder.Uri;
            return currentRequestUri;
        }
    }
}
