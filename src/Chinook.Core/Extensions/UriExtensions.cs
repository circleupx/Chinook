using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;

public static class UriExtensions
{
    public static Uri AddQueryStringsToUri(this Uri uri, IDictionary<string, StringValues> queryParameters)
    {
        var uriStrippedOfQueryParameters = uri.GetLeftPart(UriPartial.Path);
        var updatedUri = QueryHelpers.AddQueryString(uriStrippedOfQueryParameters, queryParameters);
        var uriWithQueryParameters = new Uri(updatedUri);
        return uriWithQueryParameters;
    }
}