using System.ComponentModel.DataAnnotations;

namespace MyWebsite.DataAPI.Entities
{
    public class About
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }= string.Empty;

        [Required]
        public string Content { get; set; }= string.Empty;

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }= string.Empty;

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        [MaxLength(250)]
        public string Address { get; set; } = string.Empty;
    }
}
