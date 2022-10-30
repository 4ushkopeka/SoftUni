using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class BookViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 10)]
        public string Title { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Author { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        [Url]
        public string ImageUrl { get; set; }
        [Required]
        [Range(0, 10)]
        public decimal Rating { get; set; }
    }
}
