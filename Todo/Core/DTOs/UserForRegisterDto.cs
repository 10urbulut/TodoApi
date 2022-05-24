using System.ComponentModel.DataAnnotations;

namespace Todo.Models.DTOs
{
    public class UserForRegisterDto
    {
        [Required, EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
    }
}
