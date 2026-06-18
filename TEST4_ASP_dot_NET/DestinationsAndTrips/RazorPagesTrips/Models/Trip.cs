namespace RazorPagesTrips.Models
{
    public class Trip
    {
        public int Id { get; set; } 
        public string destination { get; set; } = string.Empty;
        public int days { get; set; }
        public float price { get; set; }
        public bool overPrice { get; set; }
        public int maxPricePerDay { get; set; }
    }
}
