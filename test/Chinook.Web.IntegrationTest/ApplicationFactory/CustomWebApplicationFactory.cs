using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;

namespace Chinook.Web.IntegrationTest.ApplicationFactory
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        protected override IHostBuilder CreateHostBuilder()
        {
            var builder = base.CreateHostBuilder();
            return builder;
        }
    }
}
