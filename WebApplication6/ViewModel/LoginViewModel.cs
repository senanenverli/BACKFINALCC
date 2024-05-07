using System.ComponentModel.DataAnnotations;

namespace WebApplication6.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        public string UsernameOrEmail { get; set; } = null!;
        [Required, DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        public bool RememberMe { get; set; }
    }
}
