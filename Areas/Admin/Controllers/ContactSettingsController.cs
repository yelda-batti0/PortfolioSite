using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioSite.DAL.Context;
using PortfolioSite.DAL.Entities;
using PortfolioSite.ViewModels;

namespace PortfolioSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ContactSettingsController : Controller
    {
        private readonly AppDbContext _db;

        public ContactSettingsController(AppDbContext db)
        {
            _db = db;
        }

        // ---------- Panel metinleri ----------
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var c = await _db.Contacts.AsNoTracking().FirstOrDefaultAsync();
            ViewBag.Topics = await _db.ContactTopics.AsNoTracking().OrderBy(x => x.SortOrder).ToListAsync();

            var model = c == null ? new ContactSettingsViewModel() : new ContactSettingsViewModel
            {
                HeaderLabelTr = c.HeaderLabelTr,
                HeaderLabelEn = c.HeaderLabelEn,
                TitleTr = c.TitleTr,
                TitleEn = c.TitleEn,
                TitleAccentTr = c.TitleAccentTr,
                TitleAccentEn = c.TitleAccentEn,
                DescriptionTr = c.DescriptionTr,
                DescriptionEn = c.DescriptionEn,
                ResponseNotTr = c.ResponseNotTr,
                ResponseNotEn = c.ResponseNotEn,
                Email = c.Email
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(ContactSettingsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Topics = await _db.ContactTopics.AsNoTracking().OrderBy(x => x.SortOrder).ToListAsync();
                return View(model);
            }

            var c = await _db.Contacts.FirstOrDefaultAsync();
            if (c == null) { c = new Contact(); _db.Contacts.Add(c); }

            c.HeaderLabelTr = model.HeaderLabelTr.Trim(); c.HeaderLabelEn = model.HeaderLabelEn.Trim();
            c.TitleTr = model.TitleTr.Trim(); c.TitleEn = model.TitleEn.Trim();
            c.TitleAccentTr = model.TitleAccentTr.Trim(); c.TitleAccentEn = model.TitleAccentEn.Trim();
            c.DescriptionTr = model.DescriptionTr.Trim(); c.DescriptionEn = model.DescriptionEn.Trim();
            c.ResponseNotTr = (model.ResponseNotTr ?? "").Trim(); c.ResponseNotEn = (model.ResponseNotEn ?? "").Trim();
            c.Email = model.Email.Trim();

            await _db.SaveChangesAsync();
            TempData["Success"] = "İletişim paneli kaydedildi.";
            return RedirectToAction(nameof(Index));
        }

        // ---------- Konular ----------
        [HttpGet]
        public IActionResult CreateTopic()
        {
            var next = (_db.ContactTopics.Max(x => (int?)x.SortOrder) ?? 0) + 1;
            return View("EditTopic", new TopicEditViewModel { SortOrder = next });
        }

        [HttpGet]
        public async Task<IActionResult> EditTopic(int id)
        {
            var t = await _db.ContactTopics.AsNoTracking().FirstOrDefaultAsync(x => x.ContactTopicId == id);
            if (t == null) return NotFound();
            return View(new TopicEditViewModel
            {
                ContactTopicId = t.ContactTopicId,
                NameTr = t.NameTr,
                NameEn = t.NameEn,
                SortOrder = t.SortOrder,
                IsActive = t.IsActive
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveTopic(TopicEditViewModel model)
        {
            if (!ModelState.IsValid) return View("EditTopic", model);

            ContactTopic? t;
            if (model.ContactTopicId == 0) { t = new ContactTopic(); _db.ContactTopics.Add(t); }
            else
            {
                t = await _db.ContactTopics.FirstOrDefaultAsync(x => x.ContactTopicId == model.ContactTopicId);
                if (t == null) return NotFound();
            }

            t.NameTr = model.NameTr.Trim(); t.NameEn = model.NameEn.Trim();
            t.SortOrder = model.SortOrder; t.IsActive = model.IsActive;

            await _db.SaveChangesAsync();
            TempData["Success"] = "Konu kaydedildi.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteTopic(int id)
        {
            var t = await _db.ContactTopics.FirstOrDefaultAsync(x => x.ContactTopicId == id);
            if (t != null)
            {
                _db.ContactTopics.Remove(t);
                await _db.SaveChangesAsync();
                TempData["Success"] = "Konu silindi.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
