using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebMVC.Domain.Entities;

namespace WebMVC.Infrastructure.Configurations
{
    public class InstructionConfiguration : IEntityTypeConfiguration<Instruction>
    {
        public void Configure(EntityTypeBuilder<Instruction> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.StepNumber)
                .IsRequired();
            builder.Property(i => i.Instructions)
                .IsRequired()
                .HasMaxLength(2000);
            builder.HasOne(i => i.Recipe)
                .WithMany(r => r.Instructions)
                .HasForeignKey(i => i.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
