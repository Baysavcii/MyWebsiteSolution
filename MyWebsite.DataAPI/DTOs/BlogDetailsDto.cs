namespace MyWebsite.DataAPI.DTOs
{
    public class BlogDetailsDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string AuthorName { get; set; } = string.Empty;
        public string AuthorEmail { get; set; } = string.Empty;
        public string AuthorRole { get; set; } = string.Empty;
        public List<CommentsDto> CommentList { get; set; } = new List<CommentsDto>();
    }
}
