using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Kieszonstwory.Models;
using Microsoft.AspNetCore.Identity;

namespace Kieszonstwory.Controllers
{
    [Authorize]
    public class LokalizacjeController : Controller
    {
        private readonly AplikacjaDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public LokalizacjeController(AplikacjaDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            int ilosc = _context.Kieszonstwory.Count(x => x.Trener.UserId == _userManager.GetUserId(User));
            if (ilosc ==0)
            {
                ViewBag.Brak = "Najpierw odbierz swojego pierwszego stworka w zakładce 'Stworki'.";
            }
            return View();
        }

        public async Task<IActionResult> Wybrzeze()
        {
            var lokalizacja = await _context.Lokalizacje.FirstOrDefaultAsync(l => l.Nazwa == "Wybrzeże");

            return View(lokalizacja);
        }

        public async Task<IActionResult> Polana()
        {
            var lokalizacja = await _context.Lokalizacje.FirstOrDefaultAsync(l => l.Nazwa == "Polana");
            return View(lokalizacja);
        }

        public async Task<IActionResult> Gory()
        {
            var lokalizacja = await _context.Lokalizacje.FirstOrDefaultAsync(l => l.Nazwa == "Góry");
            return View(lokalizacja);
        }
        public IActionResult BrakStworkow()
        {
            ViewBag.Message = "Dla tej lokalizacji nie ma żadnych stworków. Skontaktuj się z administratorem.";
            return View();
        }
    }
}
