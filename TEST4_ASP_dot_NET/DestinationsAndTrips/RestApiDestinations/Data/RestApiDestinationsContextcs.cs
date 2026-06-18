using Microsoft.EntityFrameworkCore;
using NuGet.ContentModel;
namespace RestApiDestinations.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
                      : base(options) { }
    public DbSet<RestApiDestinations.Models.Destination> Destinations { get; set; } // Deine Model-Klasse 
}