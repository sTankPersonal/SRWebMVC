using Microsoft.AspNetCore.Mvc.Filters;
using WebMVC.API.Filters;
using WebMVC.Application.Services.Implementations;
using WebMVC.Application.Services.Interfaces;
using WebMVC.Domain.Interfaces.Repositories;
using WebMVC.Domain.Interfaces.Validators;
using WebMVC.Domain.Services.Validators;
using WebMVC.Infrastructure.Repositories;

namespace WebMVC.API.DIExtensions
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

            // Services
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IIngredientService, IngredientService>();
            services.AddScoped<IInstructionService, InstructionService>();
            services.AddScoped<IRecipeService, RecipeService>();
            services.AddScoped<IUnitService, UnitService>();

            return services;
        }
    }
}
