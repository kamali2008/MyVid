using System.ComponentModel.DataAnnotations;

namespace MyVid.Web.Models.Auth
{
    public class RegisterViewModel
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string PasswordConfirm { get; set; }
    }
}
