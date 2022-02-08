using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.WebUtilities;

public class UriQueryParametersWriter
{
    private Uri RequestUri;

    public UriQueryParametersWriter(Uri requestUri)
    {
        RequestUri = requestUri;
    }

    public Uri ReplaceQueryParameters(IDictionary<string, string> parameters)
    {
        var parsedQueryParameters = QueryHelpers.ParseQuery(RequestUri.Query);
        foreach (var parameterToReplace in parameters)
        {
            parsedQueryParameters.Remove(parameterToReplace.Key);
            parsedQueryParameters.Add(parameterToReplace.Key, parameterToReplace.Value);
        }

        return RequestUri.AddQueryStringsToUri(parsedQueryParameters);
    }

    public Uri StripParametersFromUri(IEnumerable<string> parameters)
    {
        var parsedQueryParameters = QueryHelpers.ParseQuery(RequestUri.Query);
        foreach (var parameterToRemove in parameters)
        {
            parsedQueryParameters.Remove(parameterToRemove);
        }
        return RequestUri.AddQueryStringsToUri(parsedQueryParameters);
    }

    public Uri StripParametersFromUri(string parameter)
    {
        var parsedQueryParameters = QueryHelpers.ParseQuery(RequestUri.Query);
        parsedQueryParameters.Remove(parameter);
        return RequestUri.AddQueryStringsToUri(parsedQueryParameters);
    }
}