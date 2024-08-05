using Application.Validators;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Registration
{
    public class RegisterationUser
    {
        [Required]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "The username must be alphanumeric.")]
        [Unique("Username")]
        public string Username { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        [MaxLength(100, ErrorMessage = "Password cannot exceed 100 characters.")]
        public string Password { get; set; }
        [Required]
        [Alphabetic]
        public string FirstName { get; set; }
        [Required]
        [Alphabetic]
        public string LastName { get; set; }
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "The phone number must contain only numeric characters.")]
        public string Phone { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        [Unique("Email")]
        public string Email { get; set; }
    }
}
