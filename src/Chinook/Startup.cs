using Chinook.Infrastructure.Database;
using Chinook.Infrastructure.Handlers;
using Chinook.Web.Middlewares;
using Chinook.Web.Resources;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddTransient<HomeResource>();
            services.AddTransient<ICustomerResource, CustomerResource>();
            services.AddDbContext<ChinookDbContext>();

            services.AddMediatR(typeof(GetCustomerResourceCollectionHandler));
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
