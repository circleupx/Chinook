using System;
using JsonApiFramework.Http;
using JsonApiFramework.JsonApi;

public static class LinkBuilder
{
    public static Link CreateResourceLink(IUrlBuilderConfiguration urlBuilderConfiguration, string resourcePath)
    {
        var urlConfiguration = UrlBuilder.Create(urlBuilderConfiguration)
        .Path(resourcePath)
        .Build();

        var link = new Link(urlConfiguration);
        return link;
    }

    public static Link CreateResourceLink(IUrlBuilderConfiguration urlBuilderConfiguration, string resourcePath, string queryString)
    {
        var urlConfiguration = UrlBuilder.Create(urlBuilderConfiguration)
        .Path(resourcePath)
        .Query(queryString)
        .Build();

        var link = new Link(urlConfiguration);
        return link;
    }

    public static Link CreateResourceLink(Uri uri, string resourcePath, string queryString)
    {
        var urlBuilderConfiguration = new UrlBuilderConfiguration(uri.Scheme, uri.Host, uri.Port);
        var urlConfiguration = UrlBuilder.Create(urlBuilderConfiguration)
        .Path(resourcePath)
        .Query(queryString)
        .Build();

        var link = new Link(urlConfiguration);
        return link;
    }

    public static Link CreateResourceLink(Uri uri)
    {
        var urlBuilderConfiguration = new UrlBuilderConfiguration(uri.Scheme, uri.Host, uri.Port);
        var urlConfiguration = UrlBuilder.Create(urlBuilderConfiguration)
        .Path(uri.AbsolutePath)
        .Query(uri.Query)
        .Build();

        var link = new Link(urlConfiguration);
        return link;
    }
}