using Library.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class AddBookViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 10)]
        public string Title { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Author { get; set; }
        [Required]
        [MaxLength(5000)]
        [MinLength(5)]
        public string Description { get; set; }
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
        [Required]
        public int CategoryId { get; set; }
        [Required]
        [Url]
        public string ImageUrl { get; set; }
        [Required]
        [Range(0, 10)]
        public decimal Rating { get; set; }
    }
}
