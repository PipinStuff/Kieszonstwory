using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Kieszonstwory.Models
{
    public class Kieszonstwor
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Nazwa { get; set; }
        [Range(1, 100)]
        public int Poziom { get; set; }
        [Required]
        [Range(1, 100)]
        public int Moc { get; set; }
        public int HP { get; set; }
        [Required]
        [Range(1, 100)]
        public int BaseHP { get; set; }
        public string? Obrazek { get; set; }

        public int TypStworaId { get; set; }
        public TypStwora TypStwora { get; set; }

        public int TrenerId { get; set; }
        public Trener Trener { get; set; }

        public int LokalizacjaId { get; set; }
        public Lokalizacja Lokalizacja { get; set; }
        public bool CzyFav { get; set; } = false;
    }
}
