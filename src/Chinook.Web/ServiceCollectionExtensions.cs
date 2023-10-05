using Chinook.Core.Extensions;
using Chinook.Core.Interfaces;
using Chinook.Infrastructure;
using Chinook.Infrastructure.Handlers;
using Chinook.Web.Resources;
using Microsoft.AspNetCore.ResponseCompression;

namespace Chinook.Web
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceExtensions(this IServiceCollection services, IConfiguration configuration)
        {
           
            services.AddSingleton<HomeResource>();
            
            services.AddTransient<ITrackResource, TrackResource>();
            services.AddTransient<IPlaylistResource, PlaylistResource>();
            services.AddTransient<IMediaTypeResource, MediaTypeResource>();
            services.AddTransient<IInvoiceItemResource, InvoiceItemResource>();
            services.AddTransient<IInvoiceResource, InvoiceResource>();
            services.AddTransient<IGenerResource, GenreResource>();
            services.AddTransient<IEmployeeResource, EmployeeResource>();
            services.AddTransient<IArtistResource, ArtistResource>();
            services.AddTransient<IAlbumResource, AlbumResource>();
            //services.AddTransient<ICustomerResource, CustomerResource>();
            //services.AddTransient<CustomerQuerySpecification>();
            
            services.AddDbContext<ChinookDbContext>();


            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
                options.Providers.Add<BrotliCompressionProvider>();
                options.Providers.Add<GzipCompressionProvider>();
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[]
                { 
                    MimeTypeKeyWords.ApplicationJsonApi
                });
            });

            services.AddTransient(provider => {
                var httpContextAccessor = provider.GetService<IHttpContextAccessor>();
                var requestUri = httpContextAccessor!.HttpContext.GetRequestUri();
                return new UriQueryParametersWriter(requestUri);
            });
            
            services.AddTransient(provider => {
                var httpContextAccessor = provider.GetService<IHttpContextAccessor>();
                var requestUri = httpContextAccessor!.HttpContext.GetRequestUri();
                return new UriQueryParametersReader(requestUri);
            });

            // Auto Registration of Handlers using Assembly Scans.
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetAlbumResourceCollectionHandler).Assembly));
            services.AddHttpContextAccessor();
            services.AddControllers()
                    .AddNewtonsoftJson();
            return services;
        }
    }
}