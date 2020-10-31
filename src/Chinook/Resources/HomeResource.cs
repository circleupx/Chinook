using Chinook.Core;
using Chinook.Core.ServiceModels;
using JsonApiFramework.JsonApi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;
using System;
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

            var displayUri = httpContextAccessor.HttpContext.Request.GetDisplayUrl();
            var currentRequestUri = new Uri(displayUri);

            using var chinookDocumentContext = new ChinookDocumentContext(currentRequestUri);
            var document = chinookDocumentContext
                        .NewDocument(currentRequestUri)
                            .SetJsonApiVersion(JsonApiVersion.Version10)
                            .Links()
                                .AddSelfLink()
                            .LinksEnd()
                            .Resource(homeResource)
                            .ResourceEnd()
                        .WriteDocument();

            return Task.FromResult(document);
        }
    }
    }
}
