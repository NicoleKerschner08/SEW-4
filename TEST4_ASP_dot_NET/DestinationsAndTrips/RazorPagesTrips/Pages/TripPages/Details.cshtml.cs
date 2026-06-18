using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesTrips.Models;

namespace RazorPagesTrips.Pages.TripPages
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesTripsContext _context;

        public DetailsModel(RazorPagesTripsContext context)
        {
            _context = context;
        }

        public Trip Trip { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = await _context.Trip.FirstOrDefaultAsync(m => m.Id == id);
            if (trip == null)
            {
                return NotFound();
            }
            else
            {
                Trip = trip;
            }
            return Page();
        }
    }
}
