using System.ComponentModel.DataAnnotations;

namespace MyWebsite.DataAPI.Entities
{
    public class Comments
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string AuthorName { get; set; } = string.Empty;

        [Required]
        public string AuthorEmail { get; set; } = string.Empty;

        [Required]
        [MaxLength(500)]
        public string Content { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Required]
        public int BlogDetailsId { get; set; }

        public BlogDetails BlogDetail { get; set; } = null!;
    }
}
