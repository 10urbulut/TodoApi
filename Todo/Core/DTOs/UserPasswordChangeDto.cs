using System.ComponentModel.DataAnnotations;

namespace Todo.Core.DTOs
{
    public class UserPasswordChangeDto
    {
        [Required, EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? NewPassword { get; set; }
        [Required]
        public string? NewPasswordAgain { get; set; }
        [Required]
        public string? OldPassword { get; set; }
    }
}
