using Chinook.Web.Middlewares;

namespace Chinook.Web
{
    public static class ApplicationBuilderExtensions 
    {
        public static IApplicationBuilder UseAppExtensions(this IApplicationBuilder app)
        {
            app.UseExceptionHandlingMiddleware();
            return app;
        }
    }   
}