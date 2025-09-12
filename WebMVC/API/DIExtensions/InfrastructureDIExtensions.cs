using Microsoft.EntityFrameworkCore;
using WebMVC.Domain.Interfaces.Repositories;
using WebMVC.Infrastructure.Data;
using WebMVC.Infrastructure.Repositories;

namespace WebMVC.API.DIExtensions
{
    public static class InfrastructureDIExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            // Database Connection String "ConnectionStrings__NeonConnection"
            var connectionString = config.GetConnectionString("NeonConnection")
                ?? throw new InvalidOperationException("Database connection string not configured.");

            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(connectionString));

            // Repositories
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IIngredientRepository, IngredientRepository>();
            services.AddScoped<IInstructionRepository, InstructionRepository>();
            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddScoped<IUnitRepository, UnitRepository>();

            return services;
        }
    }
}
