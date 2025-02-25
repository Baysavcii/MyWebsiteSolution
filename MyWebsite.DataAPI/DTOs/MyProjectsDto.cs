namespace MyWebsite.DataAPI.DTOs
{
    public class MyProjectsDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string ImageDescription { get; set; } = string.Empty;
        public string ImageName { get; set; } = string.Empty;
    }
}