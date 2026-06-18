using Microsoft.EntityFrameworkCore;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
                      : base(options) { }
    public DbSet<RestApiBook.Models.Book> Books { get; set; } // Deine Model-Klasse 
}