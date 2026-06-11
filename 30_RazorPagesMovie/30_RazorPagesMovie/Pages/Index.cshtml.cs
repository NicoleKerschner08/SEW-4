using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using _30_RazorPagesMovie.Data;
using _30_RazorPagesMovie.Models;

namespace _30_RazorPagesMovie.Pages
{
    public class IndexModel : PageModel
    {
        private readonly _30_RazorPagesMovie.Data._30_RazorPagesMovieContext _context;
        public readonly string Message;


        public IndexModel(_30_RazorPagesMovie.Data._30_RazorPagesMovieContext context)
        {
            _context = context;
            Message = "Hello from the IndexModel class!";
        }

        public IList<Movie> Movie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Movie = await _context.Movie.ToListAsync();
        }
    }
}
