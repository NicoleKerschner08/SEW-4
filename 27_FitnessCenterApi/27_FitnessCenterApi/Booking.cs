namespace _27_FitnessCenterApi
{
    public class Booking
    {
        public int Id { get; set; }
        public int memberId { get; set; }
        public int courseId { get; set; }
        public DateOnly creationDate { get; set; }
    }
}
