using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WebAPI.Models
{
    public class RegiValidator
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Name empty.")]
        [MinLength(3,ErrorMessage="Name too short.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email Address empty.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password empty.")]
        [MinLength(8,ErrorMessage="Password too short.")]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Confirm failed")]
        public string Confirm { get; set; }
        [Required(ErrorMessage = "PhoneNumber empty.")]
        public string PhoneNumber { get; set; }
    }   
}
