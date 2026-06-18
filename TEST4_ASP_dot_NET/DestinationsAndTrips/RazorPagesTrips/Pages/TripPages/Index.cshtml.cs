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
    public class IndexModel : PageModel
    {
        private readonly RazorPagesTripsContext _context;

        public IndexModel(RazorPagesTripsContext context)
        {
            _context = context;
        }

        public IList<Trip> Trip { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Trip = await _context.Trip.ToListAsync();
        }
    }
}
