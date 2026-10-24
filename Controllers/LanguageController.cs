using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioSite.Controllers
{
    public class LanguageController : Controller
    {
        [HttpGet]
        public IActionResult Set(string culture, string? returnUrl)
        {
            // Sadece izin verilen diller kabul edilir
            if (culture != "tr" && culture != "en")
                culture = "tr";

            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddYears(1),
                    IsEssential = true,
                    HttpOnly = true,
                    SameSite = SameSiteMode.Lax,
                    Secure = Request.IsHttps
                });

            // Güvenlik: sadece site içi adreslere yönlendir (open redirect koruması)
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                return LocalRedirect(returnUrl);

            return LocalRedirect("/");
        }
    }
}
