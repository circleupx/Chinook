using Chinook.Web;
using Serilog;

// Bootstrap Serilog to capture host build errors.
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Configuration.AddJsonFile("appsettings.json", false, true);
    builder.Configuration.AddJsonFile($"appsettings{builder.Environment}.json", true, true);
    builder.Configuration.AddEnvironmentVariables();
    builder.Configuration.AddCommandLine(args);

    builder.Host.ConfigureLogging(loggingBuilder => 
    {
        loggingBuilder.ClearProviders();
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .WriteTo.Console()
            .CreateLogger();
    });
    builder.Host.UseSerilog();

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddServiceExtensions(builder.Configuration);

    var app = builder.Build();

    app.UseAppExtensions();
    app.UseStaticFiles();
    app.UseHttpsRedirection();
    app.UseRouting();
    app.UseAuthorization();
    app.UseResponseCompression();
    app.MapControllers();

    await app.RunAsync();
}
catch (Exception exception)
{
    Log.Fatal(exception, "Host build error encountered, please check configurations.");
}
finally
{
    await Log.CloseAndFlushAsync();
}

public partial class Program { }