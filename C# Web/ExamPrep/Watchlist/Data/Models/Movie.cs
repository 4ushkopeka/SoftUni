using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Watchlist.Data.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 10)]
        public string Title { get; set; } = null!;
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Director { get; set; } = null!;
        [Required]
        public string ImageUrl { get; set; } = null!;
        [Required]
        [Range(0, 10)]
        public decimal Rating { get; set; }
        [Required]
        [ForeignKey(nameof(Genre))]
        public int GenreId { get; set; }
        [Required]
        public Genre Genre { get; set; }
        public List<UserMovie> UsersMovies { get; set; } = new List<UserMovie>();
    }
}
//· Has Id – a unique integer, Primary Key

//· Has Title – a string with min length 10 and max length 50 (required)

//· Has Director – a string with min length 5 and max length 50 (required)

//· Has ImageUrl – a string (required)

//· Has Rating – a decimal with min value 0.00 and max value 10.00 (required)

//· Has GenreId – an integer (required)

//· Has Genre – a Genre (required)

//· Has UsersMovies – a collection of type UserMovie
