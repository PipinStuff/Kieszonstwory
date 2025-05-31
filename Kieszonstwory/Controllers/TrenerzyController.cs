using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Kieszonstwory.Models;
using Microsoft.AspNetCore.Identity;

namespace Kieszonstwory.Controllers
{
    [Authorize]
    public class TrenerzyController : Controller
    {
        private readonly AplikacjaDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public TrenerzyController(AplikacjaDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            return View(await _context.Trenerzy.FirstOrDefaultAsync(x=>x.UserId==userId));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateName(Trener model)
        {
            var trener = await _context.Trenerzy.FindAsync(model.Id);
            if (trener == null)
                return NotFound();

            trener.Name = model.Name;
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
