using Microsoft.EntityFrameworkCore; 
using Example.Models;

namespace Example
{
    public class ExampleDbContext : DbContext
    {
        public ExampleDbContext(DbContextOptions<ExampleDbContext> options) : base(options) { }
        public DbSet<Rechnung> Rechnungen { get; set; } // Deine Model-Klasse 
        public DbSet<Example.Models.PrivateText> PrivateText { get; set; } = default!;
    }
}
