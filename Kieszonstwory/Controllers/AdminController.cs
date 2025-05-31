using Kieszonstwory.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Kieszonstwory.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly AplikacjaDbContext _context;

        public AdminController(AplikacjaDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var stworki = await _context.DzikiStwor.ToListAsync();
            return View(stworki);
        }

        public async Task<IActionResult> ListaStworkow()
        {
            var stworki = await _context.DzikiStwor.ToListAsync();
            ViewBag.Typy = new SelectList(_context.TypyStworow, "Id", "Nazwa");
            ViewBag.Lokalizacje = new SelectList(_context.Lokalizacje, "Id", "Nazwa");
            return View(stworki);
        }


        public async Task<IActionResult> ListaTypow()
        {
            var typy = await _context.TypyStworow.ToListAsync();
            ViewBag.Typy = new SelectList(_context.TypyStworow, "Id", "Nazwa");
            ViewBag.Lokalizacje = new SelectList(_context.Lokalizacje, "Id", "Nazwa");
            return View(typy);
        }

        public IActionResult DodajStworka()
        {
            ViewBag.Typy = new SelectList(_context.TypyStworow, "Id", "Nazwa");
            ViewBag.Lokalizacje = new SelectList(_context.Lokalizacje, "Id", "Nazwa");
            return View();
        }


        [HttpPost]
        public IActionResult DodajStworka(DzikiStwor stworek)
        {
            if (ModelState.IsValid)
            {
                stworek.HP = stworek.BaseHP + (stworek.Poziom - 1) * 5;
                stworek.Moc = stworek.BaseMoc + (stworek.Poziom - 1) * 2;
                _context.DzikiStwor.Add(stworek);
                _context.SaveChanges();
                return RedirectToAction("ListaStworkow");
            }

            ViewBag.Typy = new SelectList(_context.TypyStworow, "Id", "Nazwa", stworek.TypStworaId);
            ViewBag.Lokalizacje = new SelectList(_context.Lokalizacje, "Id", "Nazwa", stworek.LokalizacjaId);
            return View(stworek);
        }


        public IActionResult EdytujStworka(int id)
        {
            var stworek = _context.DzikiStwor.Find(id);
            if (stworek == null) return NotFound();

            ViewBag.Typy = new SelectList(_context.TypyStworow, "Id", "Nazwa", stworek.TypStworaId);
            ViewBag.Lokalizacje = new SelectList(_context.Lokalizacje, "Id", "Nazwa", stworek.LokalizacjaId);
            return View(stworek);
        }


        [HttpPost]
        public IActionResult EdytujStworka(DzikiStwor stworek)
        {
            if (ModelState.IsValid)
            {
                stworek.HP = stworek.BaseHP + (stworek.Poziom - 1) * 5;
                stworek.Moc = stworek.BaseMoc + (stworek.Poziom - 1) * 2;
                _context.DzikiStwor.Update(stworek);
                _context.SaveChanges();
                return RedirectToAction("ListaStworkow");
            }

            ViewBag.Typy = new SelectList(_context.TypyStworow, "Id", "Nazwa", stworek.TypStworaId);
            ViewBag.Lokalizacje = new SelectList(_context.Lokalizacje, "Id", "Nazwa", stworek.LokalizacjaId);
            return View(stworek);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UsunStworka(int id)
        {
            var stworek = _context.DzikiStwor.Find(id);
            if (stworek == null)
            {
                return NotFound();
            }

            _context.DzikiStwor.Remove(stworek);
            _context.SaveChanges();

            return RedirectToAction("ListaStworkow");
        }


        public IActionResult DodajTyp()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DodajTyp(TypStwora typ)
        {
            if (ModelState.IsValid)
            {
                _context.TypyStworow.Add(typ);
                await _context.SaveChangesAsync();
                return RedirectToAction("ListaTypow");
            }
            return View(typ);
        }

    
        public async Task<IActionResult> EdytujTyp(int id)
        {
            var typ = await _context.TypyStworow.FindAsync(id);
            if (typ == null) return NotFound();
            return View(typ);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EdytujTyp(int id, TypStwora typ)
        {
            if (id != typ.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(typ);
                await _context.SaveChangesAsync();
                return RedirectToAction("ListaTypow");
            }
            return View(typ);
        }

       
        public async Task<IActionResult> UsunTyp(int id)
        {
            var typ = await _context.TypyStworow.FindAsync(id);
            if (typ == null) return NotFound();

            _context.TypyStworow.Remove(typ);
            await _context.SaveChangesAsync();
            return RedirectToAction("ListaTypow");
        }

    }
}
