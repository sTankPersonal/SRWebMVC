using Microsoft.EntityFrameworkCore;

namespace SRwebMVC.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Ingredient> Ingredients { get; set; }
    }
}
