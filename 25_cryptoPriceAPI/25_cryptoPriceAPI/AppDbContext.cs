using Microsoft.EntityFrameworkCore;

namespace _25_cryptoPriceAPI
{
    public class AppDbContext : DbContext
    {
        public DbSet<CryptoPrice> CryptoPrices { get; set; } = null;

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
    }
}
