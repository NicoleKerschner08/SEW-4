using Microsoft.EntityFrameworkCore;
using RazorPagesTrips.Models;

public class RazorPagesTripsContext(DbContextOptions<RazorPagesTripsContext> options) : DbContext(options)
{
    public DbSet<RazorPagesTrips.Models.TravelAgency> TravelAgency { get; set; } = default!;
    public DbSet<RazorPagesTrips.Pages.TripPages.TripSelectorModel> TripSelectors { get; set; } = default!;

    public DbSet<RazorPagesTrips.Models.Trip> Trip { get; set; } = default!;
}
