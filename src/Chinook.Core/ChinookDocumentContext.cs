using Chinook.Core.ServiceModels;
using JsonApiFramework;
using JsonApiFramework.Http;
using JsonApiFramework.JsonApi;
using JsonApiFramework.Server;
using System;

namespace Chinook.Core
{
    public class ChinookDocumentContext : DocumentContext
    {
        public ChinookDocumentContext(Uri currentRequestUri)
        {
            var urlBuilderConfiguration = CreateUrlBuilderConfiguration(currentRequestUri);
            UrlBuilderConfiguration = urlBuilderConfiguration;
        }

        public ChinookDocumentContext(Uri currentRequestUri, Document document) : base(document)
        {
            var urlBuilderConfiguration = CreateUrlBuilderConfiguration(currentRequestUri);
            UrlBuilderConfiguration = urlBuilderConfiguration;
        }

        protected override void OnConfiguring(IDocumentContextOptionsBuilder optionsBuilder)
        {

            var serviceModel = ConfigurationFactory.CreateServiceModel();
            optionsBuilder.UseServiceModel(serviceModel);
            optionsBuilder.UseUrlBuilderConfiguration(UrlBuilderConfiguration);
        }

        private IUrlBuilderConfiguration UrlBuilderConfiguration { get; set; }

        private static UrlBuilderConfiguration CreateUrlBuilderConfiguration(Uri currentRequestUri)
        {
            var scheme = currentRequestUri.Scheme;
            var host = currentRequestUri.Host;
            var port = currentRequestUri.Port;
            var urlBuilderConfiguration = new UrlBuilderConfiguration(scheme, host, port);
            return urlBuilderConfiguration;
        }
    }
}
