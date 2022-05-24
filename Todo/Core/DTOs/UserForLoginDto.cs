using System.ComponentModel.DataAnnotations;

namespace Todo.Models.DTOs
{
    public class UserForLoginDto
    {
        [Required, EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
