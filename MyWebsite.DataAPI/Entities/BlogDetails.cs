using System.ComponentModel.DataAnnotations;

namespace MyWebsite.DataAPI.Entities
{
    public class BlogDetails
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Content { get; set; } = string.Empty;

        [Required]
        [Url]
        public string Image { get; set; } = string.Empty;

        [Required]
        public string AuthorName { get; set; } = string.Empty;

        [Required]
        public string AuthorEmail { get; set; } = string.Empty;

        [Required]
        public string AuthorRole { get; set; } = string.Empty;
   
        [Required]
        public int BlogId { get; set; }
        public Blog Blog { get; set; } = null!; 

        public List<Comments> CommentList { get; set; } = new List<Comments>();
    }
}
