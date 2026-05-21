namespace _27_FitnessCenterApi
{
    public class Member
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string mailAddress { get; set; }
        public List<Booking> bookings { get; set; }
    }
}
