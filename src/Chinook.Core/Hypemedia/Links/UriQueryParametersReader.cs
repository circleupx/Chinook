using System;
using System.Linq;
using JsonApiFramework.JsonApi;

public class UriQueryParametersReader
{
    private QueryParameters CurrentRequestUriQueryParameters;

    public UriQueryParametersReader(Uri requestUri)
    {
        CurrentRequestUriQueryParameters = QueryParameters.Create(requestUri);
    }

    public int GetPageNumberFromRequestUri()
    {
        var pageParameters = CurrentRequestUriQueryParameters.Page;
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
        var pageParameters = CurrentRequestUriQueryParameters.Page;
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

}