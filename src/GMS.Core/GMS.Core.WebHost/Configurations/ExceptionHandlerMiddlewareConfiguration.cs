using GMS.Core.WebHost.Middlewares;

namespace GMS.Core.WebHost.Configurations
{
    public static class ExceptionHandlerMiddlewareConfiguration
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }
}
