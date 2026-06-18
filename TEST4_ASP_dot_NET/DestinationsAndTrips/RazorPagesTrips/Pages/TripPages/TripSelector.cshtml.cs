using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RazorPagesTrips.Models;

namespace RazorPagesTrips.Pages.TripPages
{
    public class TripSelectorModel : PageModel
    {
        [BindProperty]
        public int MaxCostsPerDay { get; set; } = 0;
        public bool overPrice {  get; set; } = false;
        public int Id { get; set; }
        public string destination { get; set; } = string.Empty;
        public int days { get; set; }
        public float price { get; set; }
        public List<Trip> trips;

        public void OnPost()
        {
            foreach(var item in Model.Trips) {
                if ((item.price / item.days) > MaxCostsPerDay)
                {
                    trips.Add(item);
                }
        }
    }
}}
