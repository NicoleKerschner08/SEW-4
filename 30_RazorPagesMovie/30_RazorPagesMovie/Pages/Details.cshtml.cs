using _30_RazorPagesMovie.Models;
using _30_RazorPagesMovie.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _30_RazorPagesMovie.Pages

{

    public class DetailsModel : PageModel

    {

        private readonly _30_RazorPagesMovie.Data._30_RazorPagesMovieContext _context;

        public DetailsModel(_30_RazorPagesMovie.Data._30_RazorPagesMovieContext context)

        {

            _context = context;

        }

        public Movie Movie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)

        {

            if (id == null)

            {

                return NotFound();

            }

            var movie = await _context.Movie.FirstOrDefaultAsync(m => m.id == id);

            if (movie == null)

            {

                return NotFound();

            }

            else

            {

                Movie = movie;

            }

            return Page();

        }

    }

}

