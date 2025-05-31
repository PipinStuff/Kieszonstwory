namespace Kieszonstwory.Models
{
    public class Walka
    {
        public int Id { get; set; }
        public DzikiStwor DzikiStwor { get; set; }
        public Kieszonstwor Kieszonstwor { get; set; }
        public int LokalizacjaId { get; set; }
        public string Komunikat { get; set; } = string.Empty;
        public bool Wynik { get; set; }
    }
}
