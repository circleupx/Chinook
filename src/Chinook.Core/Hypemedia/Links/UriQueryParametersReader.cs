using System;
using System.Linq;
using JsonApiFramework.JsonApi;

public class UriQueryParametersReader
{
    private Uri CurrentRequestUri;
    private QueryParameters CurrentRequestUriQueryParameters;
    private PageConfigurationSettings PageConfigurationSettings;

    public UriQueryParametersReader(Uri requestUri, PageConfigurationSettings pageConfigurationSettings)
    {
        CurrentRequestUri = requestUri;
        CurrentRequestUriQueryParameters = QueryParameters.Create(requestUri);
        PageConfigurationSettings = pageConfigurationSettings;
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
            return PageConfigurationSettings.PageConfiguration.DefaultNumber;
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
            return PageConfigurationSettings.PageConfiguration.DefaultSize;
        }
    }

}