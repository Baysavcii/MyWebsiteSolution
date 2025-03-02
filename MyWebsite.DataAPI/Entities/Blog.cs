using System.ComponentModel.DataAnnotations;

namespace MyWebsite.DataAPI.Entities
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Title { get; set; }

        [Required]
        [MinLength(50)]
        public string Content { get; set; }

        [Url]
        public string ImageUrl { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } =DateTime.UtcNow;
    }
}
