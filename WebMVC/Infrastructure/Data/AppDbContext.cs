using Microsoft.EntityFrameworkCore;
using WebMVC.Domain.Entities;
using WebMVC.Models;

namespace WebMVC.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public DbSet<RecipeCategory> RecipeCategories { get; set; }
        public DbSet<Quantity> Quantities { get; internal set; }
        public DbSet<Instruction> RecipeSteps { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ========================
            // RecipeIngredient
            // (Join Table between Recipe and Ingredient)
            // Includes the Quantity Measurement
            // ========================
            modelBuilder.Entity<RecipeIngredient>()
                .HasKey(ri => new { ri.RecipeId, ri.IngredientId });

            modelBuilder.Entity<RecipeIngredient>()
                .HasOne(ri => ri.Recipe)
                .WithMany(r => r.RecipeIngredients)
                .HasForeignKey(ri => ri.RecipeId);

            modelBuilder.Entity<RecipeIngredient>()
                .HasOne(ri => ri.Ingredient)
                .WithMany(i => i.RecipeIngredients)
                .HasForeignKey(ri => ri.IngredientId);

            modelBuilder.Entity<RecipeIngredient>()
                .HasOne(ri => ri.Quantity)
                .WithMany(q => q.RecipeIngredients)
                .HasForeignKey(ri => ri.QuantityId);

            // ========================
            // RecipeCategory 
            // (Join Table between Recipe and Category)
            // ========================
            modelBuilder.Entity<RecipeCategory>()
                .HasKey(rc => new { rc.RecipeId, rc.CategoryId });

            modelBuilder.Entity<RecipeCategory>()
                .HasOne(rc => rc.Recipe)
                .WithMany(r => r.RecipeCategories)
                .HasForeignKey(rc => rc.RecipeId);

            modelBuilder.Entity<RecipeCategory>()
                .HasOne(rc => rc.Category)
                .WithMany(c => c.RecipeCategories)
                .HasForeignKey(rc => rc.CategoryId);

            // ========================
            // Configure decimal precision for Amount
            // ========================
            modelBuilder.Entity<RecipeIngredient>()
                .Property(ri => ri.Amount)
                .HasPrecision(10, 2);

            // ========================
            // RecipeStep relationship
            // ========================
            modelBuilder.Entity<Instruction>()
                .HasOne(rs => rs.Recipe)
                .WithMany(r => r.Steps)
                .HasForeignKey(rs => rs.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);

            // ========================
            // Seeding the database
            // ========================
            // ===== Quantities =====
            modelBuilder.Entity<Quantity>().HasData(
                new Quantity { Id = 1, Name = "Slices" },
                new Quantity { Id = 2, Name = "Grams" },
                new Quantity { Id = 3, Name = "Cups" },
                new Quantity { Id = 4, Name = "Tablespoons" },
                new Quantity { Id = 5, Name = "Teaspoons" },
                new Quantity { Id = 6, Name = "Pieces" }
            );

            // ===== Ingredients =====
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 1, Name = "Bread" },
                new Ingredient { Id = 2, Name = "Ham" },
                new Ingredient { Id = 3, Name = "Cheese" },
                new Ingredient { Id = 4, Name = "Rice" },
                new Ingredient { Id = 5, Name = "Water" },
                new Ingredient { Id = 6, Name = "Salt" },
                new Ingredient { Id = 7, Name = "Steak" },
                new Ingredient { Id = 8, Name = "Pepper" },
                new Ingredient { Id = 9, Name = "Oil" }
            );

            // ===== Categories =====
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Lunch" },
                new Category { Id = 2, Name = "Side" },
                new Category { Id = 3, Name = "Dinner" },
                new Category { Id = 4, Name = "Beef" },
                new Category { Id = 5, Name = "No Cook" },
                new Category { Id = 6, Name = "Stove Top" },
                new Category { Id = 7, Name = "One Pot" },
                new Category { Id = 8, Name = "Oven" },
                new Category { Id = 9, Name = "Cast Iron" },
                new Category { Id = 10, Name = "Barbeque" }
            );


            // ===== Recipes =====
            modelBuilder.Entity<Recipe>().HasData(
                new Recipe
                {
                    Id = 1,
                    Name = "Ham and Cheese Sandwich",
                    PrepTime = 5,
                    CookTime = 3
                },
                new Recipe
                {
                    Id = 2,
                    Name = "Stovetop Rice",
                    PrepTime = 2,
                    CookTime = 20
                },
                new Recipe
                {
                    Id = 3,
                    Name = "Forward Sear Steak",
                    PrepTime = 10,
                    CookTime = 40
                }
            );

            // ===== RecipeIngredients =====
            modelBuilder.Entity<RecipeIngredient>().HasData(
                // Sandwich
                new { RecipeId = 1, IngredientId = 1, QuantityId = 1, Amount = 2.0m },
                new { RecipeId = 1, IngredientId = 2, QuantityId = 2, Amount = 50.0m },
                new { RecipeId = 1, IngredientId = 3, QuantityId = 2, Amount = 30.0m },

                // Rice
                new { RecipeId = 2, IngredientId = 4, QuantityId = 3, Amount = 1.0m },
                new { RecipeId = 2, IngredientId = 5, QuantityId = 3, Amount = 2.0m },
                new { RecipeId = 2, IngredientId = 6, QuantityId = 5, Amount = 0.5m },

                // Steak
                new { RecipeId = 3, IngredientId = 7, QuantityId = 6, Amount = 1.0m },
                new { RecipeId = 3, IngredientId = 6, QuantityId = 5, Amount = 0.5m },
                new { RecipeId = 3, IngredientId = 8, QuantityId = 5, Amount = 0.25m },
                new { RecipeId = 3, IngredientId = 9, QuantityId = 4, Amount = 1.0m }
            );

            // ===== RecipeCategories =====
            modelBuilder.Entity<RecipeCategory>().HasData(
                // Ham and Cheese Sandwich
                new { RecipeId = 1, CategoryId = 1 }, // Lunch
                new { RecipeId = 1, CategoryId = 5 }, // No Cook

                // Stovetop Rice
                new { RecipeId = 2, CategoryId = 2 }, // Side
                new { RecipeId = 2, CategoryId = 6 }, // Stove Top
                new { RecipeId = 2, CategoryId = 7 }, // One Pot

                // Forward Sear Steak
                new { RecipeId = 3, CategoryId = 3 }, // Dinner
                new { RecipeId = 3, CategoryId = 4 }, // Beef
                new { RecipeId = 3, CategoryId = 8 }, // Oven
                new { RecipeId = 3, CategoryId = 9 }, // Cast Iron
                new { RecipeId = 3, CategoryId = 10 } // Barbeque
            );

            // ===== RecipeSteps =====
            modelBuilder.Entity<Instruction>().HasData(
                // Ham and Cheese Sandwich (RecipeId = 1)
                new Instruction { Id = 1, RecipeId = 1, StepNumber = 1, Description = "Lay out two slices of bread." },
                new Instruction { Id = 2, RecipeId = 1, StepNumber = 2, Description = "Place ham on one slice of bread." },
                new Instruction { Id = 3, RecipeId = 1, StepNumber = 3, Description = "Add cheese on top of the ham." },
                new Instruction { Id = 4, RecipeId = 1, StepNumber = 4, Description = "Top with the second slice of bread." },
                new Instruction { Id = 5, RecipeId = 1, StepNumber = 5, Description = "Toast the sandwich if desired." },

                // Stovetop Rice (RecipeId = 2)
                new Instruction { Id = 6, RecipeId = 2, StepNumber = 1, Description = "Rinse the rice under cold water." },
                new Instruction { Id = 7, RecipeId = 2, StepNumber = 2, Description = "Add rice, water, and salt to a pot." },
                new Instruction { Id = 8, RecipeId = 2, StepNumber = 3, Description = "Bring to a boil over high heat." },
                new Instruction { Id = 9, RecipeId = 2, StepNumber = 4, Description = "Reduce heat to low, cover, and simmer until water is absorbed." },
                new Instruction { Id = 10, RecipeId = 2, StepNumber = 5, Description = "Remove from heat and let stand covered for 5 minutes before serving." },

                // Forward Sear Steak (RecipeId = 3)
                new Instruction { Id = 11, RecipeId = 3, StepNumber = 1, Description = "Preheat oven to 250°F (120°C)." },
                new Instruction { Id = 12, RecipeId = 3, StepNumber = 2, Description = "Season steak with salt and pepper." },
                new Instruction { Id = 13, RecipeId = 3, StepNumber = 3, Description = "Place steak on a wire rack over a baking sheet." },
                new Instruction { Id = 14, RecipeId = 3, StepNumber = 4, Description = "Roast in oven until desired internal temperature is reached." },
                new Instruction { Id = 15, RecipeId = 3, StepNumber = 5, Description = "Heat oil in a cast iron skillet over high heat." },
                new Instruction { Id = 16, RecipeId = 3, StepNumber = 6, Description = "Sear steak on both sides until a brown crust forms." },
                new Instruction { Id = 17, RecipeId = 3, StepNumber = 7, Description = "Rest steak for 5 minutes before slicing and serving." }
            );
        }
    }
}
