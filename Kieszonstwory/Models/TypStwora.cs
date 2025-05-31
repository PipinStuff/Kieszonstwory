using System.ComponentModel.DataAnnotations;

namespace Kieszonstwory.Models
{
    public class TypStwora
    {
        public int Id { get; set; }
        [Required]
        public string Nazwa { get; set; }
        public string Opis { get; set; }

    }

}
