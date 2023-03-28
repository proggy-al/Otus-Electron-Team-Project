using GMS.Core.BusinessLogic.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace GMS.Core.WebHost.Middlewares
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionHandlerMiddleware> _logger;

        public CustomExceptionHandlerMiddleware(RequestDelegate next, ILogger<CustomExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = string.Empty;

            switch (exception)
            {
                case NotFoundException:
                    code = HttpStatusCode.NotFound;
                    break;
                case NotExistException:
                    code = HttpStatusCode.BadRequest;
                    break;
                case AccessDeniedException:
                    code = HttpStatusCode.Forbidden;
                    break;
                case EntityLockedException:
                    code = HttpStatusCode.Locked;
                    break;
              //case ValidationException validationException:
              //      code = HttpStatusCode.BadRequest;
              //      result = JsonSerializer.Serialize(validationException.Errors);
              //      break;

            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            if (result == string.Empty)
            {
                result = JsonSerializer.Serialize( new
                {
                    StatusCode = (int)code,
                    ErrorMsg = exception.Message 
                });
            }

            _logger.LogError(result);

            return context.Response.WriteAsync(result);
        }
    }
}
