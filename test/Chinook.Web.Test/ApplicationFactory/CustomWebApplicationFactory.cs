using Chinook.Infrastructure.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Chinook.Web.Test.ApplicationFactory
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(AddServices);
        }

        private void AddServices(IServiceCollection serviceCollection)
        {
            try
            {
                var dbContextService = serviceCollection.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<ChinookDbContext>));
                if (dbContextService != null)
                {
                    // remove the DbContext that is registered on StartUp.cs
                    serviceCollection.Remove(dbContextService);
                }

                // register the new DbContext, .NET Core dependency injection framework will now use the in-memory SQLite instance instead of whatever configuration was used to register the DbContext on the StartUp class.
                var connectionString = "Server=localhost;User Id=SA;Password=Test@12345;";
                serviceCollection.AddDbContext<ChinookDbContext>(contextOptions => contextOptions.UseSqlServer(connectionString));

                var builtServiceProvider = serviceCollection.BuildServiceProvider();
                using var scopedProvider = builtServiceProvider.CreateScope();

                var scopedServiceProvider = scopedProvider.ServiceProvider;

                // private field omitted for brevity
                var chinookDbContext = scopedServiceProvider.GetRequiredService<ChinookDbContext>();

                // these two lines are important, they ensure the in-memory database is created now.
                chinookDbContext.Database.OpenConnection();
                chinookDbContext.Database.EnsureCreated();

                // database is now ready to be seeded through the DbContext. The data will be available in each of your integration test due to the scope of the DbContext.
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
