using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MVCAPIs_Controller.Model
{
    public class AppUser : IdentityUser
    {
        [Required]
        public string? FullName { get; set; }
    }
}
