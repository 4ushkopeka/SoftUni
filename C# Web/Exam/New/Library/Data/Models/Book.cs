using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Library.Data.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
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
        [Required]
        [Url]
        public string ImageUrl { get; set; }
        [Required]
        [Range(0, 10)]
        public decimal Rating { get; set; }
        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        [Required]
        public Category Category { get; set; }
        public List<ApplicationUserBook> ApplicationUsersBooks { get; set; } = new List<ApplicationUserBook>();
    }
}
