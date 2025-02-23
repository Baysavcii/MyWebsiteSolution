using MyWebsite.AuthAPI.Entities;
using MyWebsite.DataAPI.Entities;

namespace MyWebsite.DataAPI.DTOs
{
    public class CommentsDto
    {
        public int Id { get; set; }
        public string AuthorId { get; set; } = string.Empty;
        public ApplicationUser Author { get; set; } = null!;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public int BlogDetailsId { get; set; }
        public BlogDetails BlogDetail { get; set; } = null!;
    }
}
