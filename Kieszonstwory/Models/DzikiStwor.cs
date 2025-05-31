using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Kieszonstwory.Models
{
    public class DzikiStwor
    {
            public int Id { get; set; }
            [Required, StringLength(50)]
            public string Nazwa { get; set; }
            [Range(1, 100)]
            public int Poziom { get; set; }
            public int Moc { get; set; }
            public int BaseMoc { get; set; }
            public int HP { get; set; }
            public int BaseHP { get; set; }
            public string? Obrazek { get; set; }

            public int TypStworaId { get; set; }

            public int LokalizacjaId { get; set; }
        }
    }

