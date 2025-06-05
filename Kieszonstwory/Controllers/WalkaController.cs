using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kieszonstwory.Models;
using Microsoft.AspNetCore.Identity;


namespace Kieszonstwory.Controllers
{
    public class WalkaController : Controller
    {
        private readonly AplikacjaDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly Random _rng = new();

        public WalkaController(AplikacjaDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index(int idLokalizacji)
        {
            var userId = _userManager.GetUserId(User);   
            var lokalizacja = await _context.Lokalizacje.FindAsync(idLokalizacji);
            var dzikiStwor = await _context.DzikiStwor
                .Where(d => d.LokalizacjaId == idLokalizacji)
                .OrderBy(x => Guid.NewGuid())
                .FirstOrDefaultAsync();
            if (dzikiStwor is null)
            {
                return RedirectToAction("BrakStworkow", "Lokalizacje");
            }

            var mojStwor = await _context.Kieszonstwory
                .Where(k => k.Trener.UserId == userId&&k.CzyFav==true)
                .FirstOrDefaultAsync();
            mojStwor.HP = mojStwor.BaseHP;
            Random rnd = new Random();
            int zakres = Math.Max(1, (int)Math.Floor(mojStwor.Poziom / 5.0));
            dzikiStwor.Poziom = Math.Max(1, mojStwor.Poziom + rnd.Next(-zakres, zakres + 1));
            dzikiStwor.HP = dzikiStwor.BaseHP + (dzikiStwor.Poziom - 1) * 5;
            dzikiStwor.Moc = dzikiStwor.BaseMoc + (dzikiStwor.Poziom - 1) * 2;
            var model = new Walka
            {
                Kieszonstwor = mojStwor,
                DzikiStwor = dzikiStwor,
                LokalizacjaId = lokalizacja.Id
            };
            _context.Walka.Add(model);
            _context.SaveChanges();
            return View(model);
        }

        [HttpPost]
        public IActionResult Atak(DzikiStwor tdziki, Kieszonstwor tmoj)
        {
            var dziki = _context.DzikiStwor.FirstOrDefault(x => x.Id == tdziki.Id);
            dziki.HP = tdziki.HP;dziki.Moc=tdziki.Moc; dziki.Poziom = tdziki.Poziom;
            var moj = _context.Kieszonstwory.FirstOrDefault(x => x.Id == tmoj.Id);
            moj.HP = tmoj.HP; moj.Moc = tmoj.Moc; moj.Poziom = tmoj.Poziom;
            var lokalizacja= _context.Lokalizacje.FirstOrDefault(x => x.Id == dziki.LokalizacjaId);
            if (dziki == null || moj == null) return NotFound();

            double dmg = moj.Moc * (_rng.NextDouble() + 0.5); 
            dziki.HP -= (int)Math.Round(dmg);
            string komunikat = $"Twój {moj.Nazwa} atakuje {dziki.Nazwa} zadając {Math.Round(dmg)} obrażeń!";
            if (dziki.HP <= 0)
            {
                moj.HP = moj.BaseHP;
                if (_rng.Next(1, 4) == 2)
                {
                    Esencja es = new Esencja
                    {
                        TrenerId = moj.TrenerId,
                        Typ = _context.TypyStworow.FirstOrDefault(x => x.Id == dziki.TypStworaId)
                    };
                    _context.Esencja.Add(es);
                    komunikat = $"Twój atak wykończył wroga. \nWygrałeś i zdobyłeś esencję typu {es.Typ.Nazwa}!";
                }
                else
                {
                    komunikat = $"Twój atak wykończył wroga. Wygrałeś!.\n Niestety nie udało Ci się nic zdobyć podczas walki.";
                }
                Trener trener = _context.Trenerzy.FirstOrDefault(x => x.UserId == _userManager.GetUserId(User));
                trener.Pokonane += 1;
                trener.Exp += _rng.Next(1, dziki.Poziom);
                if (trener.Exp > trener.Poziom * 10)
                {
                    trener.Exp -= trener.Poziom * 10;
                    trener.Poziom += 1;
                    komunikat += $"\nGratulacje! Twój poziom wzrósł do {trener.Poziom}!";
                }
                Wynik wynik= new Wynik
                {
                    Komunikat = komunikat
                };
                _context.SaveChanges();
                return RedirectToAction("Wynik", wynik);
            }

            double dmgDziki = dziki.Moc * (_rng.NextDouble() + 0.5);
            moj.HP -= (int)Math.Round(dmgDziki);
            komunikat += $"\n{dziki.Nazwa} kontratakuje zadając {Math.Round(dmgDziki)} obrażeń!";
            if (moj.HP <= 0)
            {
                komunikat = "Niestety przegrałeś gdyż kontratak przeciwnika okazał się zbyt mocny dla Twojego stworka.\n Twój kieszonkostwór został wyleczony. Spróbuj ponownie ;)";
                
                moj.HP = moj.BaseHP;
                Wynik wynik = new Wynik
                {
                    Komunikat = komunikat
                };
                _context.SaveChanges();
                return RedirectToAction("Wynik", wynik);
            }
  
            var model = new Walka
            {
                Kieszonstwor = moj,
                DzikiStwor = dziki,
                LokalizacjaId = lokalizacja.Id,
                Komunikat = komunikat
            };
            _context.SaveChanges();
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult Lap(DzikiStwor tdziki)
        {
            var dziki = _context.DzikiStwor.FirstOrDefault(x => x.Id == tdziki.Id);
            dziki.HP = tdziki.HP; dziki.Moc = tdziki.Moc; dziki.Poziom = tdziki.Poziom;dziki.BaseHP = tdziki.BaseHP;
            string komunikat = "";
            double procentUtratyHP = 1.0 - (double)dziki.HP / dziki.BaseHP;
            int zmniejszenieZakresu = (int)(procentUtratyHP * 10); 
            int zakres = Math.Max(1, 10 - zmniejszenieZakresu);
            var trener = _context.Trenerzy.FirstOrDefault(x => x.UserId == _userManager.GetUserId(User));
            int los = _rng.Next(1, 11); 
            if (los > zakres)
            {
                
                Kieszonstwor kieszon = new Kieszonstwor
                {
                    Nazwa = dziki.Nazwa,
                    Poziom = dziki.Poziom,
                    Moc = dziki.Moc,
                    HP = dziki.BaseHP,
                    BaseHP = dziki.BaseHP,
                    Obrazek = dziki.Obrazek,
                    TypStworaId = dziki.TypStworaId,
                    LokalizacjaId = dziki.LokalizacjaId,
                    TrenerId = trener.Id
                };
                trener.Złapane += 1;
                _context.Kieszonstwory.Add(kieszon);
                _context.SaveChanges();
                Wynik wynik = new Wynik
                {
                    Komunikat = $"Udało Ci się złapać {dziki.Nazwa}!",
                    Łapany = true,
                    kieszonstworId = kieszon.Id
                };
                return RedirectToAction("Wynik", wynik);
            }
            else
            {
                komunikat = $"Nie udało Ci się złapać {dziki.Nazwa}!. Osłabienie go powinno pomóc!";
            }
                var moj = _context.Kieszonstwory.Where(x=>x.Id==MojID).FirstOrDefault(); 

            double dmgDziki = dziki.Moc * (_rng.NextDouble() + 0.5);
            moj.HP -= (int)Math.Round(dmgDziki);
            komunikat += $"\n{dziki.Nazwa} kontratakuje zadając {Math.Round(dmgDziki)} obrażeń!";
            if (moj.HP <= 0)
            {
                komunikat = "Niestety przegrałeś gdyż kontratak przeciwnika okazał się zbyt mocny dla Twojego stworka.\n Twój kieszonkostwór został wyleczony. Spróbuj ponownie ;)";
                moj.HP = moj.BaseHP;
                
                Wynik wynik = new Wynik
                {
                    Komunikat = komunikat
                };
                _context.SaveChanges();
                return RedirectToAction("Wynik", wynik);
            }
            var lokalizacja = _context.Lokalizacje.FirstOrDefault(x => x.Id == dziki.LokalizacjaId);
            var model = new Walka
            {
                Kieszonstwor = moj,
                DzikiStwor = dziki,
                LokalizacjaId = lokalizacja.Id,
                Komunikat =komunikat
            };
            _context.SaveChanges();
            return View("Index", model);
        }

        public IActionResult Wynik(Wynik wynik)
        {
            wynik.kieszonstwor= _context.Kieszonstwory.FirstOrDefault(x => x.Id == wynik.kieszonstworId);
            return View(wynik);
        }

        [HttpPost]
        public IActionResult ZmienStworka(int mojId, int walkaId)
        {
            var walka = _context.Walka
        .Include(w => w.DzikiStwor)
        .Include(w => w.Kieszonstwor)
        .FirstOrDefault(w => w.Id == walkaId);



            if (walka == null) return NotFound();

            var nowyStworek = _context.Kieszonstwory.Find(mojId);
            if (nowyStworek == null) return NotFound();

            walka.Kieszonstwor = nowyStworek;
            _context.SaveChanges();

            return View("Index", walka);
        }


    }

}

