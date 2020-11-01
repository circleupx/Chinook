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
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ILogger<HomeResource> logger;

        public HomeResource(IHttpContextAccessor httpContextAccessor, ILogger<HomeResource> logger)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.logger = logger;
        }

        public Task<Document> GetHomeDocument()
        {
            var homeResource = new HomeServiceModel
            {
                Message = "Hello World"
            };

            var currentRequestUri = httpContextAccessor.HttpContext.GetCurrentRequestUri();

            var scheme = currentRequestUri.Scheme;
            var host = currentRequestUri.Host;
            var port = currentRequestUri.Port;
            var urlBuilderConfiguration = new UrlBuilderConfiguration(scheme, host, port);
            var customersResourceCollectionLink = CreateCustomerResourceCollectionLink(urlBuilderConfiguration);

            using var chinookDocumentContext = new ChinookDocumentContext(currentRequestUri);
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

            return Task.FromResult(document);
        }

        private Link CreateCustomerResourceCollectionLink(UrlBuilderConfiguration urlBuilderConfiguration)
        {
            var customersResourceCollectionLink = UrlBuilder.Create(urlBuilderConfiguration)
                                                       .Path(CustomerResourceKeyWords.Self)
                                                       .Build();
            
            return new Link(customersResourceCollectionLink);
        }
    }
}
