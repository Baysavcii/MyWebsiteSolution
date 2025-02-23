using System.ComponentModel.DataAnnotations;

namespace MyWebsite.DataAPI.Entities
{
    public class MyProjects
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Url]
        public string Image { get; set; } = string.Empty;

        [MaxLength(250)]
        public string ImageDescription { get; set; }= string.Empty;

        [Required]
        [MaxLength(100)]
        public string ImageName { get; set; }= string.Empty;
    }
}
