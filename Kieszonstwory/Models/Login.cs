using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;

namespace Kieszonstwory.Models
{
    public class Login
    {
        public string Email { get; set; }
        [Display(Name = "Hasło")]
        public string Password { get; set; }
    }
}
