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
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesTripsContext _context;

        public DeleteModel(RazorPagesTripsContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = await _context.Trip.FindAsync(id);
            if (trip != null)
            {
                Trip = trip;
                _context.Trip.Remove(Trip);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
