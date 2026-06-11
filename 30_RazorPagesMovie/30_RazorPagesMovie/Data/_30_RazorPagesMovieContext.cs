using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using _30_RazorPagesMovie.Models;

namespace _30_RazorPagesMovie.Data
{
    public class _30_RazorPagesMovieContext : DbContext
    {
        public _30_RazorPagesMovieContext (DbContextOptions<_30_RazorPagesMovieContext> options)
            : base(options)
        {
        }

        public DbSet<_30_RazorPagesMovie.Models.Movie> Movie { get; set; } = default!;
    }
}
