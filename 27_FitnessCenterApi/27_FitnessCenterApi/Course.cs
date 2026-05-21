namespace _27_FitnessCenterApi
{
    public class Course
    {
        public int Id { get; set; }
        public int memberId { get; set; }
        public double coursePrice { get; set; }
        public DateTime courseDate { get; set; }
        public DateOnly creationDate { get; set; }
    }
}