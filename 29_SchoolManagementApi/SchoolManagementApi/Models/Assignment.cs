namespace SchoolManagementApi.Models
{
    public class Assignment
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
    }
}
