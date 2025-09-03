using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebMVC.Domain.Entities;

namespace WebMVC.Infrastructure.Configurations
{
    public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(r => r.PrepTimeMinutes)
                .IsRequired();
            builder.Property(r => r.CookTimeMinutes)
                .IsRequired();
            builder.Property(r => r.Servings)
                .IsRequired();
            builder.HasMany(r => r.RecipeIngredients)
                .WithOne(ri => ri.Recipe)
                .HasForeignKey(ri => ri.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(r => r.RecipeCategories)
                .WithOne(rc => rc.Recipe)
                .HasForeignKey(rc => rc.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.OwnsMany(r => r.RecipeSteps, step =>
            {
                step.WithOwner().HasForeignKey("RecipeId");
                step.Property(s => s.StepNumber).IsRequired();
                step.Property(s => s.StepInstructions)
                    .IsRequired()
                    .HasMaxLength(1000);
                step.HasKey("RecipeId", "StepNumber"); 
            });
        }
    }
}
