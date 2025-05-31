using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Kieszonstwory.Models;
using Microsoft.EntityFrameworkCore;


namespace Kieszonstwory.Controllers
{
    public class LogowanieController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AplikacjaDbContext _context;
        public LogowanieController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, AplikacjaDbContext context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, true, false);

            if (result.Succeeded)
            {
                if (User.IsInRole("Admin"))
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    return RedirectToAction("Index", "Dashboard");
                }
            }
                

            ModelState.AddModelError("", "Nieprawidłowe dane logowania");
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Rejestracja model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = new IdentityUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                var trener = new Trener
                {
                    Name = model.Nazwa,
                    UserId = user.Id,
                    Poziom = 1,
                    Exp = 0
                };
                _context.Trenerzy.Add(trener);
                await _context.SaveChangesAsync();
                await _signInManager.SignInAsync(user, false);
                return RedirectToAction("Index", "Dashboard");
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError("Błąd rejestracji", error.Description);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Logowanie");
        }
    }
}
    

