    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Kieszonstwory.Models;
using Microsoft.AspNetCore.Identity;

namespace Kieszonstwory.Controllers
    {
        [Authorize]
        public class KieszonstworyController : Controller
        {
            private readonly AplikacjaDbContext _context;
            private readonly UserManager<IdentityUser> _userManager;

        public KieszonstworyController(AplikacjaDbContext context, UserManager<IdentityUser> userManager)
            {
                _context = context;
                _userManager = userManager;
        }

            public async Task<IActionResult> Index()
            {
            var userId = _userManager.GetUserId(User);
            var lista = await _context.Kieszonstwory.Where(x => x.Trener.UserId == userId)
                    .Include(k => k.TypStwora)
                    .Include(k => k.Trener)
                    .ToListAsync();

                return View(lista);
            }

            public async Task<IActionResult> Details(int? id)
            {
                if (id == null) return NotFound();

                var stworek = await _context.Kieszonstwory
                    .Include(k => k.TypStwora)
                    .Include(k => k.Trener)
                    .FirstOrDefaultAsync(m => m.Id == id);

                if (stworek == null) return NotFound();

                return View(stworek);
            }

            public IActionResult Create()
            {
                ViewData["TypStworaId"] = new SelectList(_context.TypyStworow, "Id", "Nazwa");
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create(Kieszonstwor stworek)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(stworek);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                ViewData["TypStworaId"] = new SelectList(_context.TypyStworow, "Id", "Nazwa", stworek.TypStworaId);
                return View(stworek);
            }

            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null) return NotFound();

                var stworek = await _context.Kieszonstwory.FindAsync(id);
                if (stworek == null) return NotFound();

                ViewData["TypStworaId"] = new SelectList(_context.TypyStworow, "Id", "Nazwa", stworek.TypStworaId);
                return View(stworek);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, Kieszonstwor stworek)
            {
                if (id != stworek.Id) return NotFound();

                if (ModelState.IsValid)
                {
                    _context.Update(stworek);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                ViewData["TypStworaId"] = new SelectList(_context.TypyStworow, "Id", "Nazwa", stworek.TypStworaId);
                return View(stworek);
            }

            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null) return NotFound();

                var stworek = await _context.Kieszonstwory
                    .Include(k => k.TypStwora)
                    .FirstOrDefaultAsync(m => m.Id == id);

                if (stworek == null) return NotFound();

                return View(stworek);
            }

            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var stworek = await _context.Kieszonstwory.FindAsync(id);
                _context.Kieszonstwory.Remove(stworek);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PrzydzielStartowego()
        {
            var userId = _userManager.GetUserId(User);
            var trener = await _context.Trenerzy.FirstOrDefaultAsync(t => t.UserId == userId);

            if (trener == null)
                return RedirectToAction("Index", "Dashboard");

            var dzikieStworki = await _context.DzikiStwor.ToListAsync();
            if (!dzikieStworki.Any())
                return RedirectToAction("Index");

            var los = new Random();
            var wybrany = dzikieStworki[los.Next(dzikieStworki.Count)];

            var nowyStworek = new Kieszonstwor
            {
                Nazwa = wybrany.Nazwa,
                Poziom = 3,
                Moc = wybrany.Moc + 3 * 2,
                HP = wybrany.HP + 3 * 5,
                BaseHP =wybrany.BaseHP+3 * 5,
                Obrazek = wybrany.Obrazek,
                TypStworaId = wybrany.TypStworaId,
                LokalizacjaId = wybrany.LokalizacjaId,
                TrenerId = trener.Id,
                CzyFav = true
            };

            _context.Kieszonstwory.Add(nowyStworek);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UstawUlubionego(int id)
        {
            var userId = _userManager.GetUserId(User);
            var stworki = await _context.Kieszonstwory
                .Where(k => k.Trener.UserId == userId)
                .ToListAsync();

            foreach (var s in stworki)
            {
                s.CzyFav = s.Id == id;
            }

            await _context.SaveChangesAsync();
            return Ok();
        }
        public IActionResult WybierzDoWalki(int walkaId)
        {
            ViewBag.TrybWalka = true;
            ViewBag.WalkaId = walkaId;
            var stworki = _context.Kieszonstwory.Where(k => k.Trener.UserId == _userManager.GetUserId(User)).ToList();
            return View("Index", stworki);
        }

        [HttpPost]
        public IActionResult Ulepsz(int id)
        {
            var userId = _userManager.GetUserId(User);

            var stworek = _context.Kieszonstwory
                .Include(k => k.Trener)
                .FirstOrDefault(k => k.Id == id && k.Trener.UserId == userId);

            if (stworek == null)
                return NotFound();

            var esencja = _context.Esencja
                .FirstOrDefault(e => e.TrenerId == stworek.TrenerId && e.Typ.Id == stworek.TypStworaId);

            if (esencja == null)
            {
                TempData["Error"] = "Nie posiadasz esencji tego typu.";
                return RedirectToAction("Index");
            }

          
            stworek.Poziom++;
            stworek.BaseHP += 5;
            stworek.Moc += 2;

          
            _context.Esencja.Remove(esencja);

            _context.SaveChanges();

            TempData["Message"] = $"{stworek.Nazwa} został ulepszony do poziomu {stworek.Poziom}!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Wymien(int id)
        {
            var userId = _userManager.GetUserId(User);

            var stworek = _context.Kieszonstwory
                .Include(k => k.Trener)
                .Include(k=>k.TypStwora)
                .FirstOrDefault(k => k.Id == id && k.Trener.UserId == userId);

            if (stworek == null)
                return NotFound();

            var esencja = new Esencja
            {
                Typ = stworek.TypStwora,
                TrenerId = stworek.TrenerId
            };

            _context.Kieszonstwory.Remove(stworek);
            _context.Esencja.Add(esencja);
            _context.SaveChanges();

            TempData["Message"] = $"{stworek.Nazwa} został wymieniony na esencję typu {stworek.TypStwora.Nazwa}.";
            return RedirectToAction("Index");
        }
    }
}


