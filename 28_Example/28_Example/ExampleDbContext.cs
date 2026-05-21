using Microsoft.EntityFrameworkCore;
namespace _28_Example
{
    public class ExampleDbContext : DbContext
    {
        public ExampleDbContext(DbContextOptions<ExampleDbContext> options) : base(options) { }
        public DbSet<Rechnung> Rechnungen { get; set; } // Deine Model-Klasse
    }
}
