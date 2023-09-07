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
using System.Threading.Tasks;

namespace Chinook.Web.Resources
{
    public class InvoiceResource : IInvoiceResource
    {
        private readonly ILogger<AlbumResource> _logger;
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public InvoiceResource(ILogger<AlbumResource> logger, IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Document> GetInvoiceResourceCollection()
        {
            var invoiceResourceCollection = await _mediator.Send(new GetInvoiceResourceCollectionCommand());
            var currentRequestUri = _httpContextAccessor.HttpContext.GetRequestUri();

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
                            .AddRelationship(CustomerResourceKeyWords.ToOneRelationshipKey, new[] { Keywords.Related })
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

        public async Task<Document> GetInvoiceResource(int resourceId)
        {
            var invoiceResource = await _mediator.Send(new GetInvoiceResourceCommand(resourceId));
            var currentRequestUri = _httpContextAccessor.HttpContext.GetRequestUri();

            using var chinookDocumentContext = new ChinookJsonApiDocumentContext(currentRequestUri);
            var document = chinookDocumentContext
                .NewDocument(currentRequestUri)
                .SetJsonApiVersion(JsonApiVersion.Version10)
                    .Links()
                        .AddSelfLink()
                        .AddUpLink()
                    .LinksEnd()
                    .Resource(invoiceResource)
                        .Relationships()
                            .AddRelationship(CustomerResourceKeyWords.ToOneRelationshipKey, new[] { Keywords.Related })
                            .AddRelationship(InvoiceItemResourceKeyWords.ToManyRelationShipKey, new[] { Keywords.Related })
                        .RelationshipsEnd()
                        .Links()
                            .AddSelfLink()
                        .LinksEnd()
                    .ResourceEnd()
                .WriteDocument();

            _logger.LogInformation("Request for {URL} generated JSON:API document {doc}", currentRequestUri, document);
            return document;
        }

        public async Task<Document> GetInvoiceResourceToCustomerResource(int resourceId)
        {
            var customerResource = await _mediator.Send(new GetInvoiceResourceToCustomerResourceCommand(resourceId));
            var currentRequestUri = _httpContextAccessor.HttpContext.GetRequestUri();

            using var chinookDocumentContext = new ChinookJsonApiDocumentContext(currentRequestUri);
            var document = chinookDocumentContext
                .NewDocument(currentRequestUri)
                .SetJsonApiVersion(JsonApiVersion.Version10)
                    .Links()
                        .AddSelfLink()
                        .AddUpLink()
                    .LinksEnd()
                    .Resource(customerResource)
                        .Links()
                            .AddSelfLink()
                        .LinksEnd()
                    .ResourceEnd()
                .WriteDocument();

            _logger.LogInformation("Request for {URL} generated JSON:API document {doc}", currentRequestUri, document);
            return document;
        }

        public async Task<Document> GetInvoiceResourceToInvoiceItemResourceCollection(int resourceId)
        {
            var invoiceItemResourceCollection = await _mediator.Send(new GetInvoiceResourceToInvoiceItemResourceCollectionCommand(resourceId));
            var currentRequestUri = _httpContextAccessor.HttpContext.GetRequestUri();

            using var chinookDocumentContext = new ChinookJsonApiDocumentContext(currentRequestUri);
            var document = chinookDocumentContext
                .NewDocument(currentRequestUri)
                .SetJsonApiVersion(JsonApiVersion.Version10)
                    .Links()
                        .AddSelfLink()
                        .AddUpLink()
                    .LinksEnd()
                    .ResourceCollection(invoiceItemResourceCollection)
                        .Links()
                            .AddSelfLink()
                        .LinksEnd()
                    .ResourceCollectionEnd()
                .WriteDocument();

            _logger.LogInformation("Request for {URL} generated JSON:API document {doc}", currentRequestUri, document);
            return document;
        }
    }
}