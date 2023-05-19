using Chinook.Core.Extensions;
using Chinook.Core.Interfaces;
using Chinook.Infrastructure.Database;
using Chinook.Infrastructure.Handlers;
using Chinook.Web.Middlewares;
using Chinook.Web.Resources;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Chinook
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Read AppSettings
            var pageConfigurationSettings = Configuration.Get<PageConfigurationSettings>();

            services.AddSingleton(pageConfigurationSettings);
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
            services.AddTransient<ICustomerResource, CustomerResource>();
            services.AddTransient<CustomerQuerySpecification>();
            services.AddDbContext<ChinookDbContext>();

            services.AddTransient<UriQueryParametersWriter>(provider => {
                var httpContextAccessor = provider.GetService<IHttpContextAccessor>();
                var requestUri = httpContextAccessor.HttpContext.GetCurrentRequestUri();
                return new UriQueryParametersWriter(requestUri);
            });
            
            services.AddTransient<UriQueryParametersReader>(provider => {
                var pageAppSettings = provider.GetService<PageConfigurationSettings>();
                var httpContextAccessor = provider.GetService<IHttpContextAccessor>();
                var requestUri = httpContextAccessor.HttpContext.GetCurrentRequestUri();
                return new UriQueryParametersReader(requestUri, pageAppSettings);
            });

            // Auto Registration of Handlers using Assembly Scans.
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetAlbumResourceCollectionHandler).GetTypeInfo().Assembly));
            services.AddHttpContextAccessor();
            services.AddControllers()
                .AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseExceptionHandlingMiddleware();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
