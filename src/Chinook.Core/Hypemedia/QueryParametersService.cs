using System;
using System.Collections.Generic;
using System.Linq;
using JsonApiFramework.JsonApi;
using Microsoft.AspNetCore.WebUtilities;

public class QueryParameterService
{
    private readonly Uri _requestUri;
    private readonly QueryParameters _queryParameters;

    public QueryParameterService(Uri requestUri)
    {
        _requestUri = requestUri;
        _queryParameters = QueryParameters.Create(requestUri);
    }

    public int GetPageNumberFromRequestUri()
    {
        var pageParameters = _queryParameters.Page;
        var hasPageParameterInRequestUri = pageParameters.TryGetValue(UriKeyWords.number, out var pageParamertersInUri);
        
        if(hasPageParameterInRequestUri)
        {
            var pageNumber = pageParamertersInUri.First();
            return int.Parse(pageNumber);
        }
        else
        {
            return 1;
        }
    }

    public int GetSizeNumberFromRequestUri()
    {
        var pageParameters = _queryParameters.Page;
        var hasPageParameterInRequestUri = pageParameters.TryGetValue(UriKeyWords.size, out var pageParamertersInUri);
        
        if(hasPageParameterInRequestUri)
        {
            var pageSize = pageParamertersInUri.First();
            return int.Parse(pageSize);
        }
        else
        {
            return 50;
        }
    }

    public Uri ReplaceQueryParameters(IDictionary<string, string> parameters)
    {
        var parsedQueryParameters = QueryHelpers.ParseQuery(_requestUri.Query);
        foreach (var parameterToReplace in parameters)
        {
            parsedQueryParameters.Remove(parameterToReplace.Key);
            parsedQueryParameters.Add(parameterToReplace.Key, parameterToReplace.Value);
        }

        return _requestUri.AddQueryStringsToUri(parsedQueryParameters);
    }

    public Uri StripParametersFromUri(IEnumerable<string> parameters)
    {
        var parsedQueryParameters = QueryHelpers.ParseQuery(_requestUri.Query);
        foreach (var parameterToRemove in parameters)
        {
            parsedQueryParameters.Remove(parameterToRemove);
        }
        return _requestUri.AddQueryStringsToUri(parsedQueryParameters);
    }

    public Uri StripParametersFromUri(string parameter)
    {
        var parsedQueryParameters = QueryHelpers.ParseQuery(_requestUri.Query);
        parsedQueryParameters.Remove(parameter);
        return _requestUri.AddQueryStringsToUri(parsedQueryParameters);
    }

    public Dictionary<string, string> ParseFilterQueryString()
    {
        var filterDictionary = new Dictionary<string, string>();
        if (string.IsNullOrWhiteSpace(_requestUri.Query))
        {
            return filterDictionary;
        }

        var requestUriQuery = _requestUri.Query;
        var startIndex = requestUriQuery[(requestUriQuery.IndexOf(UriKeyWords.QuerySeparator) + 1)..];
        var startIndexCopy = startIndex;

        foreach (var filter in startIndexCopy.Split(UriKeyWords.Ampersand))
        {
            var array = filter.Split(UriKeyWords.Equal);
            var filterKey = Uri.UnescapeDataString(array[0]);
            var filterValue = Uri.UnescapeDataString(array[1]);
            var filterKeySplit = filterKey.Split(UriKeyWords.LeftBracket, UriKeyWords.RightBracket);

            if (filterKeySplit.Length == 3 && filterKeySplit[2] == string.Empty)
            {
                var filterQueryString = filterKeySplit[0];
                var filterQueryStringValue = filterKeySplit[1];
                if (string.Compare(filterQueryString, UriKeyWords.Filter, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    filterDictionary[filterQueryStringValue] = filterValue;
                }
            }
        }

        return filterDictionary;
    }
}
