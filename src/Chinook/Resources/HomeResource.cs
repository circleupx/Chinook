using Chinook.Core;
using Chinook.Core.Constants;
using Chinook.Core.Extensions;
using Chinook.Core.ServiceModels;
using JsonApiFramework.Http;
using JsonApiFramework.JsonApi;
using JsonApiFramework.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Chinook.Web.Resources
{
    public class HomeResource
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<HomeResource> _logger;

        public HomeResource(IHttpContextAccessor httpContextAccessor, ILogger<HomeResource> logger)
        {
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        public Task<Document> GetHomeDocument()
        {
            var homeResource = new Home
            {
                Message = "Hello World"
            };

            var currentRequestUri = _httpContextAccessor.HttpContext.GetCurrentRequestUri();

            var scheme = currentRequestUri.Scheme;
            var host = currentRequestUri.Host;
            var port = currentRequestUri.Port;
            var urlBuilderConfiguration = new UrlBuilderConfiguration(scheme, host, port);
            var customersResourceCollectionLink = CreateCustomerResourceCollectionLink(urlBuilderConfiguration);

            using var chinookDocumentContext = new ChinookJsonApiDocumentContext(currentRequestUri);
            var document = chinookDocumentContext
                        .NewDocument(currentRequestUri)
                            .SetJsonApiVersion(JsonApiVersion.Version10)
                            .Links()
                                .AddSelfLink()
                            .LinksEnd()
                            .Resource(homeResource)
                                .Links()
                                    .AddLink(CustomerResourceKeyWords.Self, customersResourceCollectionLink)
                                 .LinksEnd()
                            .ResourceEnd()
                        .WriteDocument();
            _logger.LogInformation("Request for {URL} generated JSON:API document {doc}", currentRequestUri, document);
            return Task.FromResult(document);
        }

        private static Link CreateCustomerResourceCollectionLink(UrlBuilderConfiguration urlBuilderConfiguration)
        {
            var customersResourceCollectionLink = UrlBuilder.Create(urlBuilderConfiguration)
                                                       .Path(CustomerResourceKeyWords.Self)
                                                       .Build();
            
            return new Link(customersResourceCollectionLink);
        }
    }
}
