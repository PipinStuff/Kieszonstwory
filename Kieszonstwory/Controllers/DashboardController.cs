using Kieszonstwory.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kieszonstwory.Controllers
{

    [Authorize]
    public class DashboardController : Controller
    {

        private readonly AplikacjaDbContext   _context;
        private readonly UserManager<IdentityUser> _userManager;
        public DashboardController(AplikacjaDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var trener = await _context.Trenerzy.FirstOrDefaultAsync(t => t.UserId == userId);
            return View(trener);
        }
    }
}
