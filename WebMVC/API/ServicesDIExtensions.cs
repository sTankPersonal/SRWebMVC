using WebMVC.Application.Services.Implementations;
using WebMVC.Application.Services.Interfaces;
using WebMVC.Domain.Interfaces.Repositories;
using WebMVC.Domain.Interfaces.Validators;
using WebMVC.Domain.Services.Validators;
using WebMVC.Infrastructure.Repositories;

namespace WebMVC.API
{
    public static class ServicesDIExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Domain Services Validators
            services.AddScoped<IRecipeValidator, RecipeValidator>();

            // Infrastructure / Repositories
            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IIngredientRepository, IngredientRepository>();

            // Application Services
            services.AddScoped<IRecipeService, RecipeService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IIngredientService, IngredientService>();

            return services;
        }
    }
}
