using System.ComponentModel.DataAnnotations;

namespace Library.Data.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Name { get; set; } = null!;
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
