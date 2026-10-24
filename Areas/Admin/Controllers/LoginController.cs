using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PortfolioSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<IdentityUser> _signIn;

        public LoginController(SignInManager<IdentityUser> signIn)
        {
            _signIn = signIn;
        }

        [HttpGet]
        public IActionResult Index(string? returnUrl)
        {
            if (User.Identity?.IsAuthenticated == true)
                return RedirectToAction("Index", "Dashboard", new { area = "Admin" });

            ViewData["ReturnUrl"] = returnUrl;
            return View(new LoginInput());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginInput model, string? returnUrl)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _signIn.PasswordSignInAsync(
                model.Email, model.Password, model.RememberMe, lockoutOnFailure: true);

            if (result.Succeeded)
            {
                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    return LocalRedirect(returnUrl);
                return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
            }

            // Hata mesajı bilerek genel: e-posta mı şifre mi yanlış belli etmez
            ModelState.AddModelError("", result.IsLockedOut
                ? "Çok fazla hatalı deneme. 15 dakika sonra tekrar deneyin."
                : "E-posta veya şifre hatalı.");

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signIn.SignOutAsync();
            return RedirectToAction("Index");
        }
    }

    public class LoginInput
    {
        [Required(ErrorMessage = "E-posta gerekli.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta yazın.")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Şifre gerekli.")]
        public string Password { get; set; } = "";

        public bool RememberMe { get; set; }
    }
}

