using System.ComponentModel.DataAnnotations;

namespace AgenziaConsulenzaAMM.MVC.Models
{
    public class UserLoginViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
