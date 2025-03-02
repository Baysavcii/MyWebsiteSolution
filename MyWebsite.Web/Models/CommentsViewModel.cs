
namespace MyWebsite.Web.Models
{
    public class CommentsViewModel
    {
        public int Id { get; set; }
        public string AuthorId { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public int BlogDetailsId { get; set; }
    }
}
