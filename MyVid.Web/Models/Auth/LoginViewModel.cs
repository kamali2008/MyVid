using System.ComponentModel.DataAnnotations;

namespace MyVid.Web.Models.Auth
{
    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
