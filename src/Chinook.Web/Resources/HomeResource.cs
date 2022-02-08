using Chinook.Core;
using Chinook.Core.Models;
using Chinook.Core.Constants;
using Chinook.Core.Extensions;
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
                Message = "Chinook Sample JSON:API Project"
            };

            var currentRequestUri = _httpContextAccessor.HttpContext.GetCurrentRequestUri();

            var scheme = currentRequestUri.Scheme;
            var host = currentRequestUri.Host;
            var port = currentRequestUri.Port;
            var urlBuilderConfiguration = new UrlBuilderConfiguration(scheme, host, port);
            var customersResourceCollectionLink = CreateCustomerResourceCollectionLink(urlBuilderConfiguration);
            var albumResourceCollectionLink = CreateAlbumResourceCollectionLink(urlBuilderConfiguration);
            var artistResourceCollectionLink = CreateArtistResourceCollectionLink(urlBuilderConfiguration);
            var employeeResourceCollectionLink = CreateEmployeeResourceCollectionLink(urlBuilderConfiguration);
            var genreResourceCollectionLink = CreateGenreResourceCollectionLink(urlBuilderConfiguration);
            var invoiceResourceCollectionLink = CreateInvoiceResourceCollectionLink(urlBuilderConfiguration);
            var invoiceItemResourceCollectionLink = CreateInvoiceItemResourceCollectionLink(urlBuilderConfiguration);
            var mediaTypeResourceCollectionLink = CreateMediaTypeResourceCollectionLink(urlBuilderConfiguration);
            var playlistResourceCollectionLink = CreatePlaylistResourceCollectionLink(urlBuilderConfiguration);
            var trackResourceCollectionLink = CreateTrackResourceCollectionLink(urlBuilderConfiguration);

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
                                    .AddLink(AlbumResourceKeyWords.Self, albumResourceCollectionLink)
                                    .AddLink(ArtistResourceKeyWords.Self, artistResourceCollectionLink)
                                    .AddLink(EmployeeResourceKeyWords.Self, employeeResourceCollectionLink)
                                    .AddLink(GenreResourceKeyWords.Self, genreResourceCollectionLink)
                                    .AddLink(InvoiceResourceKeyWords.Self, invoiceResourceCollectionLink)
                                    .AddLink(InvoiceItemResourceKeyWords.Self, invoiceItemResourceCollectionLink)
                                    .AddLink(MediaTypeResourceKeyWords.Self, mediaTypeResourceCollectionLink)
                                    .AddLink(PlaylistResourceKeyWords.Self, playlistResourceCollectionLink)
                                    .AddLink(TrackResourceKeyWords.Self, trackResourceCollectionLink)
                                 .LinksEnd()
                            .ResourceEnd()
                        .WriteDocument();
            _logger.LogInformation("Request for {URL} generated JSON:API document {doc}", currentRequestUri, document);
            return Task.FromResult(document);
        }

        private static Link CreateTrackResourceCollectionLink(UrlBuilderConfiguration urlBuilderConfiguration)
        {
            var trackResourceCollectionLink = UrlBuilder.Create(urlBuilderConfiguration)
                                                     .Path(TrackResourceKeyWords.Self)
                                                     .Build();

            return new Link(trackResourceCollectionLink);
        }

        private static Link CreatePlaylistResourceCollectionLink(UrlBuilderConfiguration urlBuilderConfiguration)
        {
            var playlistResourceCollectionLink = UrlBuilder.Create(urlBuilderConfiguration)
                                                     .Path(PlaylistResourceKeyWords.Self)
                                                     .Build();

            return new Link(playlistResourceCollectionLink);
        }

        private static Link CreateMediaTypeResourceCollectionLink(UrlBuilderConfiguration urlBuilderConfiguration)
        {
            var mediaTypeResourceCollectionLink = UrlBuilder.Create(urlBuilderConfiguration)
                                                     .Path(MediaTypeResourceKeyWords.Self)
                                                     .Build();

            return new Link(mediaTypeResourceCollectionLink);
        }

        private static Link CreateInvoiceItemResourceCollectionLink(UrlBuilderConfiguration urlBuilderConfiguration)
        {
            var invoiceItemResourceCollectionLink = UrlBuilder.Create(urlBuilderConfiguration)
                                                     .Path(InvoiceItemResourceKeyWords.Self)
                                                     .Build();

            return new Link(invoiceItemResourceCollectionLink);
        }

        private static Link CreateInvoiceResourceCollectionLink(UrlBuilderConfiguration urlBuilderConfiguration)
        {
            var invoiceResourceCollectionLink = UrlBuilder.Create(urlBuilderConfiguration)
                                                     .Path(InvoiceResourceKeyWords.Self)
                                                     .Build();

            return new Link(invoiceResourceCollectionLink);
        }

        private static Link CreateCustomerResourceCollectionLink(UrlBuilderConfiguration urlBuilderConfiguration)
        {
            var customersResourceCollectionLink = UrlBuilder.Create(urlBuilderConfiguration)
                                                       .Path(CustomerResourceKeyWords.Self)
                                                       .Build();
            
            return new Link(customersResourceCollectionLink);
        }

        private static Link CreateAlbumResourceCollectionLink(UrlBuilderConfiguration urlBuilderConfiguration)
        {
            var albumResourceCollectionLink = UrlBuilder.Create(urlBuilderConfiguration)
                                                       .Path(AlbumResourceKeyWords.Self)
                                                       .Build();

            return new Link(albumResourceCollectionLink);
        }

        private static Link CreateArtistResourceCollectionLink(UrlBuilderConfiguration urlBuilderConfiguration)
        {
            var artistResourceCollectionLink = UrlBuilder.Create(urlBuilderConfiguration)
                                                       .Path(ArtistResourceKeyWords.Self)
                                                       .Build();

            return new Link(artistResourceCollectionLink);
        }

        private static Link CreateEmployeeResourceCollectionLink(UrlBuilderConfiguration urlBuilderConfiguration)
        {
            var employeeResourceCollectionLink = UrlBuilder.Create(urlBuilderConfiguration)
                                                       .Path(EmployeeResourceKeyWords.Self)
                                                       .Build();

            return new Link(employeeResourceCollectionLink);
        }

        private static Link CreateGenreResourceCollectionLink(UrlBuilderConfiguration urlBuilderConfiguration)
        {
            var genreResourceCollectionLink = UrlBuilder.Create(urlBuilderConfiguration)
                                                       .Path(GenreResourceKeyWords.Self)
                                                       .Build();

            return new Link(genreResourceCollectionLink);
        }
    }
}
