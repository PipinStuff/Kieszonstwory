    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Authorization;
    using Kieszonstwory.Models;

    namespace Kieszonstwory.Controllers
    {
        [Authorize(Roles = "Administrator")]
        public class TypyStworowController : Controller
        {
            private readonly AplikacjaDbContext _context;

            public TypyStworowController(AplikacjaDbContext context)
            {
                _context = context;
            }

            public async Task<IActionResult> Index()
            {
                return View(await _context.TypyStworow.ToListAsync());
            }

            public async Task<IActionResult> Details(int? id)
            {
                if (id == null) return NotFound();

                var typ = await _context.TypyStworow.FirstOrDefaultAsync(m => m.Id == id);
                if (typ == null) return NotFound();

                return View(typ);
            }

            public IActionResult Create()
            {
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create(TypStwora typ)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(typ);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(typ);
            }

            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null) return NotFound();

                var typ = await _context.TypyStworow.FindAsync(id);
                if (typ == null) return NotFound();

                return View(typ);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, TypStwora typ)
            {
                if (id != typ.Id) return NotFound();

                if (ModelState.IsValid)
                {
                    _context.Update(typ);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                return View(typ);
            }

            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null) return NotFound();

                var typ = await _context.TypyStworow.FirstOrDefaultAsync(m => m.Id == id);
                if (typ == null) return NotFound();

                return View(typ);
            }

            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var typ = await _context.TypyStworow.FindAsync(id);
                _context.TypyStworow.Remove(typ);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
        }
    }


