﻿using System.ComponentModel.DataAnnotations;

namespace MyWebsite.DataAPI.Entities
{
    public class Feature
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }=string.Empty;

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }= string.Empty;

        [Required]
        [Url]
        public string ImageUrl { get; set; }
    }
}
