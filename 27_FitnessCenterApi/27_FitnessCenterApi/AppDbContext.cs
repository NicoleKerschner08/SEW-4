using Microsoft.EntityFrameworkCore;

namespace _27_FitnessCenterApi
{
    public class AppDbContext : DbContext
    {
        public DbSet<Booking> bookings { get; set; } = null;
        public DbSet<Member> members { get; set; } = null;
        public DbSet<Course> courses { get; set; } = null;

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }


    }

}
