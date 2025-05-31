using System.ComponentModel.DataAnnotations;

namespace Kieszonstwory.Models
{
    public class Lokalizacja
    {
        public int Id { get; set; }
        [Required]
        public string Nazwa { get; set; }
    }

}
