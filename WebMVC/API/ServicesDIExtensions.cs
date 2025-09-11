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
            services.AddScoped<ICategoryValidator, CategoryValidator>();
            services.AddScoped<IIngredientValidator, IngredientValidator>();
            services.AddScoped<IInstructionValidator, InstructionValidator>();
            services.AddScoped<IInstructionValidator, InstructionValidator>();
            services.AddScoped<IRecipeValidator, RecipeValidator>();
            services.AddScoped<IUnitValidator, UnitValidator>();


            // Infrastructure / Repositories
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IIngredientRepository, IngredientRepository>();
            services.AddScoped<IInstructionRepository, InstructionRepository>();
            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddScoped<IUnitRepository, UnitRepository>();


            // Application Services
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IIngredientService, IngredientService>();
            services.AddScoped<IInstructionService, InstructionService>();
            services.AddScoped<IRecipeService, RecipeService>();
            services.AddScoped<IUnitService, UnitService>();


            return services;
        }
    }
}
