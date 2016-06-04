using aspnetconf.crosscutting.helper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Nest;
using System.Diagnostics;
using System.Threading.Tasks;

namespace aspnetconf.crosscutting.middleware
{
    public class RequestLoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IElasticClient _logger;

        public RequestLoggerMiddleware(RequestDelegate next, IElasticClient logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var watch = Stopwatch.StartNew();
            await _next(context);
            watch.Stop();

            await _logger.IndexAsync(new Log
            {
                uri = context.Request.Path.Value,
                method = context.Request.Method,
                host = context.Connection.RemoteIpAddress.ToString(),
                duration = watch.ElapsedMilliseconds
            }, index => index.Index("aspnet"));
        }
    }

    public static class RequestLoggerMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestLogger(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestLoggerMiddleware>();
        }
    }
}
