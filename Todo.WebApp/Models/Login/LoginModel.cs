using System.ComponentModel.DataAnnotations;

namespace Todo.WebApp.Models.Login
{
    public class LoginModel
    {
        [Required]
        public string email { get; set; }

        [Required]
        public string password { get; set; }
    }
}
