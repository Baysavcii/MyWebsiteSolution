﻿using System.ComponentModel.DataAnnotations;

namespace MyWebsite.AuthAPI.DTOs
{
    public class RegisterRequest
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        [MaxLength(100, ErrorMessage = "Password must be at most 100 characters long.")]
        public string Password { get; set; }
    }
}
