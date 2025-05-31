using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kieszonstwory.Models
{
    public class Trener
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Required]
        public string UserId { get; set; }
        
        public IdentityUser User { get; set; }
        public int Poziom { get; set; }

        public int Exp { get; set; }

        public int Złapane { get; set; }
        public int Pokonane { get; set; }
    }

}
