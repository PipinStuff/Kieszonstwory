using System.ComponentModel.DataAnnotations;

namespace Kieszonstwory.Models
{
    public class Rejestracja
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Powtórz hasło")]
        [Compare("Password", ErrorMessage = "Hasła muszą się zgadzać.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Nazwa (Nick)")]
        public string Nazwa { get; set; }
    }
}
