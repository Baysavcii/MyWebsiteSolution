using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using MyWebsite.AuthAPI.Entities;

namespace MyWebsite.DataAPI.Entities
{
    public class BlogDetails
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Content { get; set; } = string.Empty;

        [Required]
        [Url]
        public string Image { get; set; } = string.Empty;

        public string AuthorId { get; set; } = string.Empty;
        [Required]
        public ApplicationUser Author { get; set; }

        public List<Comments> CommentList { get; set; } = new List<Comments>();
    }
}
