using MyWebsite.AuthAPI.Entities;
using MyWebsite.DataAPI.Entities;
using System.ComponentModel.DataAnnotations;

public class Comments
{
    public int Id { get; set; }

    [Required]
    public string AuthorId { get; set; } = string.Empty;

    [Required]
    public ApplicationUser Author { get; set; } = null!;

    [Required]
    [MaxLength(500)]
    public string Content { get; set; } = string.Empty; 

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    [Required]
    public int BlogDetailsId { get; set; }

    public BlogDetails BlogDetail { get; set; } = null!; 
}
