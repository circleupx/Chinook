using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Chinook.Core.Extensions
{
    public static class SerilogExtensions
    {
        public static ILoggingBuilder UseSerilog(this ILoggingBuilder builder, IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .Enrich.FromLogContext()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            return builder;
        }
    }
}
