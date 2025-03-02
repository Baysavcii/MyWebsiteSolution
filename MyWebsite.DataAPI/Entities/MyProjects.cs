using System.ComponentModel.DataAnnotations;

namespace MyWebsite.DataAPI.Entities
{
    public class MyProjects
    {
        [Key]
        public int Id { get; set; }

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
