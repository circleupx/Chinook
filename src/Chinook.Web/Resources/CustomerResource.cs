using Chinook.Core;
using Chinook.Core.Constants;
using Chinook.Core.Extensions;
using Chinook.Core.Interfaces;
using Chinook.Infrastructure.Commands;
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
        private readonly UriQueryParametersReader _uriQueryParametersReader;
        private readonly UriQueryParametersWriter _uriQueryParametersWriter;
        private readonly Uri _currentRequestUri;

        public CustomerResource(
            ILogger<CustomerResource> logger,
            IMediator mediator,
            IHttpContextAccessor httpContextAccessor,
            UriQueryParametersReader uriQueryParametersReader,
            UriQueryParametersWriter uriQueryParametersWritery)
        {
            _logger = logger;
            _mediator = mediator;
            _uriQueryParametersReader = uriQueryParametersReader;
            _uriQueryParametersWriter = uriQueryParametersWritery;
            _currentRequestUri = httpContextAccessor.HttpContext.GetRequestUri();
        }

        public async Task<Document> GetCustomerResourceCollection()
        {
            var customerResourceResult = await _mediator.Send(new GetCustomerResourceCollectionCommand());

            // Build hypermedia links
            var linktToCustomerJsonSchema = SchemaLinksBuilder.BuildLinkToCustomerSchema(_currentRequestUri);
            var linkBuilder = new PaginationLinkWriter(_uriQueryParametersReader, _uriQueryParametersWriter, customerResourceResult.Count);

            using var chinookDocumentContext = new ChinookJsonApiDocumentContext(_currentRequestUri);
            var document = chinookDocumentContext
                .NewDocument(_currentRequestUri)
                .SetJsonApiVersion(JsonApiVersion.Version10)
                    .Links()
                        .AddSelfLink()
                        .AddUpLink()
                        .AddLink(LinksKeyWords.next, linkBuilder.GetNextPageLink())
                        .AddLink(LinksKeyWords.last, linkBuilder.GetLastPageLink())
                        .AddLink(LinksKeyWords.first, linkBuilder.GetFirstPageLink())
                        .AddLink(LinksKeyWords.prev, linkBuilder.GetPreviousPageLink())
                        .AddLink(LinksKeyWords.describedBy, linktToCustomerJsonSchema)
                    .LinksEnd()
                    .ResourceCollection(customerResourceResult.Value)
                        .Relationships()
                            .AddRelationship(InvoiceResourceKeyWords.ToManyRelationShipKey, new[] { Keywords.Related })
                        .RelationshipsEnd()
                        .Links()
                            .AddSelfLink()
                        .LinksEnd()
                    .ResourceCollectionEnd()
                .WriteDocument();

            _logger.LogInformation("Request for {URL} generated JSON:API document {doc}", _currentRequestUri, document);
            return document;
        }

        public async Task<Document> GetCustomerResource(int resourceId)
        {
            var customerResource = await _mediator.Send(new GetCustomerResourceCommand(resourceId));

            using var chinookDocumentContext = new ChinookJsonApiDocumentContext(_currentRequestUri);
            var document = chinookDocumentContext
                .NewDocument(_currentRequestUri)
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

            _logger.LogInformation("Request for {URL} generated JSON:API document {doc}", _currentRequestUri, document);
            return document;
        }

        public async Task<Document> GetCustomerResourceToInvoiceResourceCollection(int resourceId)
        {
            var invoiceResourceCollection = await _mediator.Send(new GetCustomerResourceToInvoiceResourceCollectionCommand(resourceId));

            using var chinookDocumentContext = new ChinookJsonApiDocumentContext(_currentRequestUri);
            var document = chinookDocumentContext
                .NewDocument(_currentRequestUri)
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

            _logger.LogInformation("Request for {URL} generated JSON:API document {doc}", _currentRequestUri, document);
            return document;
        }

        public async Task<Document> CreateCustomerResource(Document jsonApiDocument)
        {
            var createdCustomerResource = await _mediator.Send(new CreateCustomerResourceCommand(jsonApiDocument));

            using var chinookDocumentContext = new ChinookJsonApiDocumentContext(_currentRequestUri);
            var document = chinookDocumentContext
                .NewDocument(_currentRequestUri)
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

            _logger.LogInformation("Request for {URL} generated JSON:API document {doc}", _currentRequestUri, document);
            return document;
        }
    }
}