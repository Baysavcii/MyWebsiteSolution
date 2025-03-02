namespace MyWebsite.DataAPI.DTOs
{
    public class CommentsDto
    {
        public int Id { get; set; }
        public string AuthorName { get; set; } = string.Empty;
        public string AuthorEmail { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public int BlogDetailsId { get; set; }
    }
}
