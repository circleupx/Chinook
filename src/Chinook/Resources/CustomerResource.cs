using Chinook.Core;
using Chinook.Core.Constants;
using Chinook.Core.Extensions;
using Chinook.Infrastructure.Commands;
using JsonApiFramework.Http;
using JsonApiFramework.JsonApi;
using JsonApiFramework.Server;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Chinook.Web.Resources
{
    public class CustomerResource : ICustomerResource
    {
        private readonly ILogger<CustomerResource> _logger;
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CustomerResource(ILogger<CustomerResource> logger, IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Document> GetCustomerResourceCollection()
        {
            var customerResourceCollection = await _mediator.Send(new GetCustomerResourceCollectionCommand());
            var currentRequestUri = _httpContextAccessor.HttpContext.GetCurrentRequestUri();
            var linktToCustomerJsonSchema = CreateLinkToCustomerSchemas(currentRequestUri);

            using var chinookDocumentContext = new ChinookJsonApiDocumentContext(currentRequestUri);
            var document = chinookDocumentContext
                .NewDocument(currentRequestUri)
                .SetJsonApiVersion(JsonApiVersion.Version10)
                    .Links()
                        .AddSelfLink()
                        .AddUpLink()
                        .AddLink(JsonApiKeyWords.DescribedBy, linktToCustomerJsonSchema)
                    .LinksEnd()
                    .ResourceCollection(customerResourceCollection)
                        .Relationships()
                            .AddRelationship(InvoiceResourceKeyWords.ToManyRelationShipKey, new[] { Keywords.Related })
                        .RelationshipsEnd()
                        .Links()
                            .AddSelfLink()
                        .LinksEnd()
                    .ResourceCollectionEnd()
                .WriteDocument();

            _logger.LogInformation("Request for {URL} generated JSON:API document {doc}", currentRequestUri, document);
            return document;
        }

        public async Task<Document> GetCustomerResource(int resourceId)
        {
            var customerResource = await _mediator.Send(new GetCustomerResourceCommand(resourceId));
            var currentRequestUri = _httpContextAccessor.HttpContext.GetCurrentRequestUri();

            using var chinookDocumentContext = new ChinookJsonApiDocumentContext(currentRequestUri);
            var document = chinookDocumentContext
                .NewDocument(currentRequestUri)
                .SetJsonApiVersion(JsonApiVersion.Version10)
                    .Links()
                        .AddSelfLink()
                        .AddUpLink()
                    .LinksEnd()
                    .Resource(customerResource)
                         .Relationships()
                            .AddRelationship(InvoiceResourceKeyWords.ToManyRelationShipKey, new[] { Keywords.Related })
                        .RelationshipsEnd()
                        .Links()
                            .AddSelfLink()
                        .LinksEnd()
                    .ResourceEnd()
                .WriteDocument();

            _logger.LogInformation("Request for {URL} generated JSON:API document {doc}", currentRequestUri, document);
            return document;
        }

        public async Task<Document> GetCustomerResourceToInvoiceResourceCollection(int resourceId)
        {
            var invoiceResourceCollection = await _mediator.Send(new GetCustomerResourceToInvoiceResourceCollectionCommand(resourceId));
            var currentRequestUri = _httpContextAccessor.HttpContext.GetCurrentRequestUri();

            using var chinookDocumentContext = new ChinookJsonApiDocumentContext(currentRequestUri);
            var document = chinookDocumentContext
                .NewDocument(currentRequestUri)
                .SetJsonApiVersion(JsonApiVersion.Version10)
                    .Links()
                        .AddSelfLink()
                        .AddUpLink()
                    .LinksEnd()
                    .ResourceCollection(invoiceResourceCollection)
                        .Relationships()
                            .AddRelationship(InvoiceItemResourceKeyWords.ToManyRelationShipKey, new[] { Keywords.Related })
                        .RelationshipsEnd()
                        .Links()
                            .AddSelfLink()
                        .LinksEnd()
                    .ResourceCollectionEnd()
                .WriteDocument();

            _logger.LogInformation("Request for {URL} generated JSON:API document {doc}", currentRequestUri, document);
            return document;
        }

        public async Task<Document> CreateCustomerResource(Document jsonApiDocument)
        {

            var createdCustomerResource = await _mediator.Send(new CreateCustomerResourceCommand(jsonApiDocument));
            var currentRequestUri = _httpContextAccessor.HttpContext.GetCurrentRequestUri();

            using var chinookDocumentContext = new ChinookJsonApiDocumentContext(currentRequestUri);
            var document = chinookDocumentContext
                .NewDocument(currentRequestUri)
                .SetJsonApiVersion(JsonApiVersion.Version10)
                    .Links()
                        .AddSelfLink()
                        .AddUpLink()
                    .LinksEnd()
                    .Resource(createdCustomerResource)
                        .Relationships()
                            .AddRelationship(InvoiceResourceKeyWords.ToManyRelationShipKey, new[] { Keywords.Related })
                        .RelationshipsEnd()
                        .Links()
                            .AddSelfLink()
                        .LinksEnd()
                    .ResourceEnd()
                .WriteDocument();

            _logger.LogInformation("Request for {URL} generated JSON:API document {doc}", currentRequestUri, document);
            return document;
        }

        private static Link CreateLinkToCustomerSchemas(Uri currentRequestUrl)
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
}