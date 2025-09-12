using Microsoft.AspNetCore.Mvc.Filters;
using WebMVC.API.Filters;

namespace WebMVC.API.DIExtensions
{
    public static class WebDIExtensions
    {
        public static IServiceCollection AddWeb(this IServiceCollection services)
        {
            // Filters
            services.AddScoped<IExceptionFilter, KeyNotFoundExceptionFilter>();
            services.AddScoped<IExceptionFilter, ValidationExceptionFilter>();

            return services;
        }
    }
}
