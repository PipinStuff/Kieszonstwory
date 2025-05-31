namespace Kieszonstwory.Models
{
    public class Wynik
    {
        public string Komunikat { get; set; }
        public bool Łapany { get; set; } = false;
        public Kieszonstwor kieszonstwor { get; set; }
        public int kieszonstworId { get; set; }

    }
}
