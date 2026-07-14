using System.ComponentModel.DataAnnotations;

namespace MVCAPIs_Controller.DTOs
{
    public class RegisterDTO
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        public string? FullNmae { get; set; }
    }
}
