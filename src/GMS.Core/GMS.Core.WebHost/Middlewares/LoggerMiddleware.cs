using System.Diagnostics;

namespace GMS.Core.WebHost.Middlewares
{
    public class LoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public LoggerMiddleware(RequestDelegate next, ILogger logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var stopWatch = new Stopwatch();
            try
            {
                stopWatch.Start();
                await _next(context);
                stopWatch.Stop();
            }
            finally
            {
                _logger.Information(
                    @"ClientIP: {clientIP}
                    Request: {method}
                    URL: {url}
                    StatusCode: {statusCode}
                    ResponseTime: {responseTime} ms",
                    context.Connection.RemoteIpAddress?.ToString(),
                    context.Request?.Method,
                    context.Request?.Path.Value,
                    context.Response?.StatusCode,
                    stopWatch.ElapsedMilliseconds);
            }
        }
    }
}
