using Chinook.Core.Extensions;
using JsonApiFramework.JsonApi;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Chinook.Web.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception exception)
            {
                await HandleException(httpContext, exception);
            }
        }

        private async Task<Task> HandleException(HttpContext httpContext, Exception exceptionContext)
        {
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var errorsDocument = new ErrorsDocument();
            var exceptionCollection = exceptionContext.GetAllExceptions();
            foreach (var exception in exceptionCollection)
            {
                _logger.LogError(exception, "Error encountered while executing request.");
                var pointer = JsonConvert.SerializeObject(new { pointer = exception.Source });
                var exceptionSource = JObject.Parse(pointer);
                var eventTitle = exception.GetType().Name;
                var eventId = RandomNumberGenerator.GetInt32(10000);
                var @event = new EventId(eventId, eventTitle);
                var linkDictionary = new Dictionary<string, Link>
                {
                    {
                        Keywords.About, new Link(exception.HelpLink)
                    }
                };
                var targetSite = exception.TargetSite.Name;
                var meta = new JObject { ["targetSite"] = targetSite };

                var errorException = new ErrorException(
                    Error.CreateId(@event.Id.ToString()),
                    HttpStatusCode.InternalServerError,
                    Error.CreateNewId(),
                    @event.Name,
                    exception.Message,
                    exceptionSource,
                    new Links(linkDictionary),
                    meta);

                errorsDocument.AddError(errorException);
            }

            var jsonResponse = await errorsDocument.ToJsonAsync();
            return httpContext.Response.WriteAsync(jsonResponse);
        }
    }
}
