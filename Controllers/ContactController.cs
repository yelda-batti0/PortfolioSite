using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using PortfolioSite.DAL.Context;
using PortfolioSite.DAL.Entities;
using PortfolioSite.ViewModels;

namespace PortfolioSite.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IStringLocalizer<SharedResource> _l;

        public ContactController(AppDbContext db, IStringLocalizer<SharedResource> l)
        {
            _db = db;
            _l = l;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendMessage(ContactFormViewModel model)
        {
            // Honeypot: bot ise başarılı gibi davran, kaydetme
            if (!string.IsNullOrWhiteSpace(model.Website))
                return Json(new { success = true, message = _l["Contact_Text"].Value });

            if (!ModelState.IsValid)
            {
                var key = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .FirstOrDefault();

                var message = string.IsNullOrEmpty(key) ? _l["Form_CheckForm"].Value : _l[key].Value;
                return Json(new { success = false, message });
            }

            var since = DateTime.UtcNow.AddMinutes(-10);
            var email = model.EmailAddress.Trim();
            int recent = await _db.ContactMessages
                .CountAsync(x => x.Email == email && x.CreatedAt > since);

            if (recent >= 3)
                return Json(new { success = false, message = _l["Form_TooMany"].Value });

            var entity = new ContactMessage
            {
                FullName = model.FullName.Trim(),
                Email = email,
                Topic = model.SubjectTopic?.Trim() ?? "",
                Message = model.MessageBody.Trim(),
                Language = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "en" ? "en" : "tr",
                CreatedAt = DateTime.UtcNow,
                IsRead = false
            };

            _db.ContactMessages.Add(entity);
            await _db.SaveChangesAsync();

            return Json(new { success = true, message = _l["Contact_Text"].Value });
        }
    }
}