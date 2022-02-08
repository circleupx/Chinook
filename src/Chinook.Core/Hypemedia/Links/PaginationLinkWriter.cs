using System;
using System.Collections.Generic;
using JsonApiFramework.JsonApi;

public class PaginationLinkWriter
{
    private readonly PagedList _pagedList;
    private readonly UriQueryParametersWriter _uriQueryParametersWriter;

    public PaginationLinkWriter(UriQueryParametersReader uriQueryParametersReader, UriQueryParametersWriter uriQueryParametersWriter, int totalCount)
    {
        var pageNumber = uriQueryParametersReader.GetPageNumberFromRequestUri();
        var pageSize = uriQueryParametersReader.GetSizeNumberFromRequestUri();
        
        _pagedList = new PagedList(totalCount, pageNumber, pageSize);
        _uriQueryParametersWriter = uriQueryParametersWriter;
    }

    public Link GetNextPageLink()
    {
        if (_pagedList.HasNextPage())
        {
            var nextPageNumber = _pagedList.GetNextPageNumber();
            var nextPageSize = _pagedList.GetPageSize();
            var updatedParameters = GetPageQueryParameters(nextPageNumber, nextPageSize);
            var nextPageUri = _uriQueryParametersWriter.ReplaceQueryParameters(updatedParameters);
            var nextPageLink = LinkBuilder.CreateResourceLink(nextPageUri);
            return nextPageLink;
        }
        else
        {
            return Link.Empty;
        }
    }

    public Link GetPreviousPageLink()
    {
        if (_pagedList.HasPreviousPage())
        {
            var nextPageNumber = _pagedList.GetPreviousPageNumber();
            var nextPageSize = _pagedList.GetPageSize();
            var updatedParameters = GetPageQueryParameters(nextPageNumber, nextPageSize);
            var nextPageUri = _uriQueryParametersWriter.ReplaceQueryParameters(updatedParameters);
            var nextPageLink = LinkBuilder.CreateResourceLink(nextPageUri);
            return nextPageLink;
        }
        else
        {
            return Link.Empty;
        }
    }

    public Link GetLastPageLink()
    {
        var nextPageNumber = _pagedList.GetLastPageNumber();
        var nextPageSize = _pagedList.GetPageSize();
        var updatedParameters = GetPageQueryParameters(nextPageNumber, nextPageSize);
        var nextPageUri = _uriQueryParametersWriter.ReplaceQueryParameters(updatedParameters);
        var nextPageLink = LinkBuilder.CreateResourceLink(nextPageUri);
        return nextPageLink;
    }

    public Link GetFirstPageLink()
    {
        var nextPageNumber = _pagedList.GetFirstPageNumber();
        var nextPageSize = _pagedList.GetPageSize();
        var updatedParameters = GetPageQueryParameters(nextPageNumber, nextPageSize);
        var nextPageUri = _uriQueryParametersWriter.ReplaceQueryParameters(updatedParameters);
        var nextPageLink = LinkBuilder.CreateResourceLink(nextPageUri);
        return nextPageLink;
    }

    private IDictionary<string, string> GetPageQueryParameters(int pageNumber, int pageSize)
    {
        var updatedParameters = new Dictionary<string, string>
        {
            {UriKeyWords.PageNumber, pageNumber.ToString()},
            {UriKeyWords.PageSize, pageSize.ToString()}
        };

        return updatedParameters;
    }
}