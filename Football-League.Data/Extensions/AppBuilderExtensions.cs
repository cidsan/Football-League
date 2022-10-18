using Football_League.Data.Middlewares;

using Microsoft.AspNetCore.Builder;

namespace Football_League.Data.Extensions
{
    public static class AppBuilderExtensions
    {
        public static IApplicationBuilder ExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}
