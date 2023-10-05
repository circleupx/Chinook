using System;
using JsonApiFramework.Http;
using JsonApiFramework.JsonApi;

public static class SchemaLinksBuilder
{
    public static Link BuildLinkToCustomerSchema(Uri currentRequestUrl)
    {
        var scheme = currentRequestUrl.Scheme;
        var host = currentRequestUrl.Host;
        var port = currentRequestUrl.Port;

        var urlBuilderConfiguration = new UrlBuilderConfiguration(scheme, host, port);
        var uriToCustomerSchemas = UrlBuilder.Create(urlBuilderConfiguration)
            .Path("customers")
            .Path("schemas")
            .Build();
        
        var linkToCustomerSchemas = new Link(uriToCustomerSchemas);
        return linkToCustomerSchemas;
    }
}