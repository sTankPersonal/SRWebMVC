using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebMVC.Domain.Entities;

namespace WebMVC.Infrastructure.Configurations
{
    public class RecipeIngredientConfiguration : IEntityTypeConfiguration<RecipeIngredient>
    {
        public void Configure(EntityTypeBuilder<RecipeIngredient> builder)
        {
            builder.HasKey(ri => new { ri.RecipeId, ri.IngredientId });
            builder.HasOne(ri => ri.Recipe)
                .WithMany(r => r.RecipeIngredients)
                .HasForeignKey(ri => ri.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(ri => ri.Ingredient)
                .WithMany(i => i.RecipeIngredients)
                .HasForeignKey(ri => ri.IngredientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.OwnsOne(ri => ri.Measurement, m =>
            {
                m.Property(me => me.Amount)
                    .IsRequired()
                    .HasMaxLength(50);
                m.Property(me => me.UnitId)
                    .IsRequired();
                m.HasOne(me => me.Unit)
                    .WithMany()
                    .HasForeignKey(me => me.UnitId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
