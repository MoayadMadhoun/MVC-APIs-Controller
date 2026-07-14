using System.ComponentModel.DataAnnotations;

namespace MVCAPIs_Controller.DTOs
{
    public class LoginDTO
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; } = null;
    }
}
