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
    public class SocialMediaController : Controller
    {
        private readonly AppDbContext _db;

        public SocialMediaController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _db.SocialMedias.AsNoTracking().OrderBy(x => x.SortOrder).ToListAsync();
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var next = (_db.SocialMedias.Max(x => (int?)x.SortOrder) ?? 0) + 1;
            return View("Edit", new SocialEditViewModel { SortOrder = next });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var s = await _db.SocialMedias.AsNoTracking().FirstOrDefaultAsync(x => x.SocialMediaId == id);
            if (s == null) return NotFound();

            return View(new SocialEditViewModel
            {
                SocialMediaId = s.SocialMediaId,
                Title = s.Title,
                Url = s.Url,
                SortOrder = s.SortOrder,
                IsActive = s.IsActive
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(SocialEditViewModel model)
        {
            // Sadece http/https linkleri kabul edilir
            if (!Uri.TryCreate((model.Url ?? "").Trim(), UriKind.Absolute, out var uri)
                || (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps))
                ModelState.AddModelError(nameof(model.Url), "Link http:// veya https:// ile başlamalı.");

            if (!ModelState.IsValid)
                return View("Edit", model);

            SocialMedia? s;
            if (model.SocialMediaId == 0)
            {
                s = new SocialMedia();
                _db.SocialMedias.Add(s);
            }
            else
            {
                s = await _db.SocialMedias.FirstOrDefaultAsync(x => x.SocialMediaId == model.SocialMediaId);
                if (s == null) return NotFound();
            }

            s.Title = model.Title.Trim();
            s.Url = model.Url.Trim();
            s.SortOrder = model.SortOrder;
            s.IsActive = model.IsActive;

            await _db.SaveChangesAsync();

            TempData["Success"] = "Link kaydedildi.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var s = await _db.SocialMedias.FirstOrDefaultAsync(x => x.SocialMediaId == id);
            if (s != null)
            {
                _db.SocialMedias.Remove(s);
                await _db.SaveChangesAsync();
                TempData["Success"] = "Link silindi.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

