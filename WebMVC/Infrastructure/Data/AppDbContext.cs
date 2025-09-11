using Microsoft.EntityFrameworkCore;
using WebMVC.Domain.Entities;

namespace WebMVC.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Ingredient> Ingredients => Set<Ingredient>();
        public DbSet<Instruction> Instructions => Set<Instruction>();
        public DbSet<Recipe> Recipes => Set<Recipe>();
        public DbSet<RecipeCategory> RecipeCategories => Set<RecipeCategory>();
        public DbSet<RecipeIngredient> RecipeIngredients => Set<RecipeIngredient>();
        public DbSet<Unit> Units => Set<Unit>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
