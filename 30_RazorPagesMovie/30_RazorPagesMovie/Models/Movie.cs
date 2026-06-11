using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace _30_RazorPagesMovie.Models
{
    public class Movie
    {
        public int id { get; set; }
        [DisplayName("This is my movie title")]
        public string? Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; } 
        public string? Genre { get; set; }
        public decimal Price { get; set; }
        
    }
}
