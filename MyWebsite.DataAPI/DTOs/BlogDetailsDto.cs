namespace MyWebsite.DataAPI.DTOs
{
    public class BlogDetailsDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string AuthorId { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public int CommentCount { get; set; }
    }
}