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
    public class InvoiceItemResource : IInvoiceItemResource
    {
        private readonly ILogger<AlbumResource> _logger;
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public InvoiceItemResource(ILogger<AlbumResource> logger, IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Document> GetInvoiceItemResourceCollection()
        {
            var invoiceItemResourceCollection = await _mediator.Send(new GetInvoiceItemResourceCollectionCommand());
            var currentRequestUri = _httpContextAccessor.HttpContext.GetCurrentRequestUri();

            using var chinookDocumentContext = new ChinookJsonApiDocumentContext(currentRequestUri);
            var document = chinookDocumentContext
                .NewDocument(currentRequestUri)
                .SetJsonApiVersion(JsonApiVersion.Version10)
                    .Links()
                        .AddSelfLink()
                        .AddUpLink()
                    .LinksEnd()
                    .ResourceCollection(invoiceItemResourceCollection)
                        .Relationships()
                            .AddRelationship(InvoiceResourceKeyWords.ToOneRelationshipKey, new[] { Keywords.Related })
                            .AddRelationship(TrackResourceKeyWords.ToOneRelationshipKey, new[] { Keywords.Related })
                        .RelationshipsEnd()
                        .Links()
                            .AddSelfLink()
                        .LinksEnd()
                    .ResourceCollectionEnd()
                .WriteDocument();

            _logger.LogInformation("Request for {URL} generated JSON:API document {doc}", currentRequestUri, document);
            return document;
        }

        public async Task<Document> GetInvoiceItemResource(int resourceId)
        {
            var invoiceItemResource = await _mediator.Send(new GetInvoiceItemResourceCommand(resourceId));
            var currentRequestUri = _httpContextAccessor.HttpContext.GetCurrentRequestUri();

            using var chinookDocumentContext = new ChinookJsonApiDocumentContext(currentRequestUri);
            var document = chinookDocumentContext
                .NewDocument(currentRequestUri)
                .SetJsonApiVersion(JsonApiVersion.Version10)
                    .Links()
                        .AddSelfLink()
                        .AddUpLink()
                    .LinksEnd()
                    .Resource(invoiceItemResource)
                        .Relationships()
                            .AddRelationship(InvoiceResourceKeyWords.ToOneRelationshipKey, new[] { Keywords.Related })
                            .AddRelationship(TrackResourceKeyWords.ToOneRelationshipKey, new[] { Keywords.Related })
                        .RelationshipsEnd()
                        .Links()
                            .AddSelfLink()
                        .LinksEnd()
                    .ResourceEnd()
                .WriteDocument();

            _logger.LogInformation("Request for {URL} generated JSON:API document {doc}", currentRequestUri, document);
            return document;
        }

        public async Task<Document> GetInvoiceItemResourceToInvoiceResource(int resourceId)
        {
            var invoiceResource = await _mediator.Send(new GetInvoiceItemResourceToInvoiceResourceCommand(resourceId));
            var currentRequestUri = _httpContextAccessor.HttpContext.GetCurrentRequestUri();

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
                        .RelationshipsEnd()
                        .Links()
                            .AddSelfLink()
                        .LinksEnd()
                    .ResourceEnd()
                .WriteDocument();

            _logger.LogInformation("Request for {URL} generated JSON:API document {doc}", currentRequestUri, document);
            return document;
        }

        public async Task<Document> GetInvoiceItemResourceToTrackResource(int resourceId)
        {
            var trackResource = await _mediator.Send(new GetInvoiceItemResourceToTrackResourceCommand(resourceId));
            var currentRequestUri = _httpContextAccessor.HttpContext.GetCurrentRequestUri();

            using var chinookDocumentContext = new ChinookJsonApiDocumentContext(currentRequestUri);
            var document = chinookDocumentContext
                .NewDocument(currentRequestUri)
                .SetJsonApiVersion(JsonApiVersion.Version10)
                    .Links()
                        .AddSelfLink()
                        .AddUpLink()
                    .LinksEnd()
                    .Resource(trackResource)
                        .Relationships()
                            .AddRelationship(AlbumResourceKeyWords.ToOneRelationshipKey, new[] { Keywords.Related })
                            .AddRelationship(GenreResourceKeyWords.ToOneRelationshipKey, new[] { Keywords.Related })
                            .AddRelationship(MediaTypeResourceKeyWords.ToOneRelationshipKey, new[] { Keywords.Related })
                            .AddRelationship(InvoiceItemResourceKeyWords.ToManyRelationShipKey, new[] { Keywords.Related })
                            .AddRelationship(PlaylistTrackResourceKeyWords.ToManyRelationShipKey, new[] { Keywords.Related })
                        .RelationshipsEnd()
                        .Links()
                            .AddSelfLink()
                        .LinksEnd()
                    .ResourceEnd()
                .WriteDocument();

            _logger.LogInformation("Request for {URL} generated JSON:API document {doc}", currentRequestUri, document);
            return document;
        }
    }
}