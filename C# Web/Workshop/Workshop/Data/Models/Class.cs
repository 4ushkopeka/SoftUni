using System.ComponentModel.DataAnnotations;

namespace Workshop.Data.Models
{
    public class Post
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MinLength(10)]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        [MinLength(30)]
        [MaxLength(1500)]
        public string Content { get; set; }
    }
}
