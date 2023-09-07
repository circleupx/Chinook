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
    public class TrackResource : ITrackResource
    {
        private readonly ILogger<AlbumResource> _logger;
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TrackResource(ILogger<AlbumResource> logger, IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Document> GetTrackResourceCollection()
        {
            var trackResourceCollection = await _mediator.Send(new GetTrackResourceCollectionCommand());
            var currentRequestUri = _httpContextAccessor.HttpContext.GetRequestUri();

            using var chinookDocumentContext = new ChinookJsonApiDocumentContext(currentRequestUri);
            var document = chinookDocumentContext
                .NewDocument(currentRequestUri)
                .SetJsonApiVersion(JsonApiVersion.Version10)
                    .Links()
                        .AddSelfLink()
                        .AddUpLink()
                    .LinksEnd()
                    .ResourceCollection(trackResourceCollection)
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
                    .ResourceCollectionEnd()
                .WriteDocument();

            _logger.LogInformation("Request for {URL} generated JSON:API document {doc}", currentRequestUri, document);
            return document;
        }

        public async Task<Document> GetTrackResource(int resourceId)
        {
            var trackResource = await _mediator.Send(new GetTrackResourceCommand(resourceId));
            var currentRequestUri = _httpContextAccessor.HttpContext.GetRequestUri();

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

        public async Task<Document> GetTrackResourceToAlbumResource(int resourceId)
        {
            var albumResource = await _mediator.Send(new GetTackResourceToAlbumResourceCommand(resourceId));
            var currentRequestUri = _httpContextAccessor.HttpContext.GetRequestUri();

            using var chinookDocumentContext = new ChinookJsonApiDocumentContext(currentRequestUri);
            var document = chinookDocumentContext
                .NewDocument(currentRequestUri)
                .SetJsonApiVersion(JsonApiVersion.Version10)
                    .Links()
                        .AddSelfLink()
                        .AddUpLink()
                    .LinksEnd()
                    .Resource(albumResource)
                        .Links()
                            .AddSelfLink()
                        .LinksEnd()
                    .ResourceEnd()
                .WriteDocument();

            _logger.LogInformation("Request for {URL} generated JSON:API document {doc}", currentRequestUri, document);
            return document;
        }

        public async Task<Document> GetTrackResourceToGenreResource(int resourceId)
        {
            var genreResource = await _mediator.Send(new GetTackResourceToGenreResourceCommand(resourceId));
            var currentRequestUri = _httpContextAccessor.HttpContext.GetRequestUri();

            using var chinookDocumentContext = new ChinookJsonApiDocumentContext(currentRequestUri);
            var document = chinookDocumentContext
                .NewDocument(currentRequestUri)
                .SetJsonApiVersion(JsonApiVersion.Version10)
                    .Links()
                        .AddSelfLink()
                        .AddUpLink()
                    .LinksEnd()
                    .Resource(genreResource)
                        .Links()
                            .AddSelfLink()
                        .LinksEnd()
                    .ResourceEnd()
                .WriteDocument();

            _logger.LogInformation("Request for {URL} generated JSON:API document {doc}", currentRequestUri, document);
            return document;
        }

        public async Task<Document> GetTrackResourceToMediaTypeResource(int resourceId)
        {
            var mediaTypeResource = await _mediator.Send(new GetTackResourceToMediaTypeResourceCommand(resourceId));
            var currentRequestUri = _httpContextAccessor.HttpContext.GetRequestUri();

            using var chinookDocumentContext = new ChinookJsonApiDocumentContext(currentRequestUri);
            var document = chinookDocumentContext
                .NewDocument(currentRequestUri)
                .SetJsonApiVersion(JsonApiVersion.Version10)
                    .Links()
                        .AddSelfLink()
                        .AddUpLink()
                    .LinksEnd()
                    .Resource(mediaTypeResource)
                        .Links()
                            .AddSelfLink()
                        .LinksEnd()
                    .ResourceEnd()
                .WriteDocument();

            _logger.LogInformation("Request for {URL} generated JSON:API document {doc}", currentRequestUri, document);
            return document;
        }

        public async Task<Document> GetTrackResourceToInvoiceItemResourceCollection(int resourceId)
        {
            var mediaTypeResource = await _mediator.Send(new GetTackResourceToInvoiceItemResourceCollectionCommand(resourceId));
            var currentRequestUri = _httpContextAccessor.HttpContext.GetRequestUri();

            using var chinookDocumentContext = new ChinookJsonApiDocumentContext(currentRequestUri);
            var document = chinookDocumentContext
                .NewDocument(currentRequestUri)
                .SetJsonApiVersion(JsonApiVersion.Version10)
                    .Links()
                        .AddSelfLink()
                        .AddUpLink()
                    .LinksEnd()
                    .ResourceCollection(mediaTypeResource)
                        .Links()
                            .AddSelfLink()
                        .LinksEnd()
                    .ResourceCollectionEnd()
                .WriteDocument();

            _logger.LogInformation("Request for {URL} generated JSON:API document {doc}", currentRequestUri, document);
            return document;
        }

        public Task<Document> GetTrackResourceToPlaylistTrackResourceCollection(int resourceId)
        {
            throw new System.NotImplementedException();
        }
    }
}