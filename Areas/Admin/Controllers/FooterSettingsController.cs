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
    public class FooterSettingsController : Controller
    {
        private readonly AppDbContext _db;

        public FooterSettingsController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var f = await _db.Footers.AsNoTracking().FirstOrDefaultAsync();

            var model = f == null ? new FooterEditViewModel() : new FooterEditViewModel
            {
                ClosingStatementTr = f.ClosingStatementTr,
                ClosingStatementEn = f.ClosingStatementEn,
                AvailabilityTextTr = f.AvailabilityTextTr,
                AvailabilityTextEn = f.AvailabilityTextEn,
                IsAvailable = f.IsAvailable,
                TitleTr = f.TitleTr,
                TitleEn = f.TitleEn,
                DescriptionTr = f.DescriptionTr,
                DescriptionEn = f.DescriptionEn,
                ColophonTextTr = f.ColophonTextTr,
                ColophonTextEn = f.ColophonTextEn,
                ColophonNoteTr = f.ColophonNoteTr,
                ColophonNoteEn = f.ColophonNoteEn,
                CopyrightTextTr = f.CopyrightTextTr,
                CopyrightTextEn = f.CopyrightTextEn,
                LocationText = f.LocationText
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(FooterEditViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var f = await _db.Footers.FirstOrDefaultAsync();
            if (f == null) { f = new Footer(); _db.Footers.Add(f); }

            f.ClosingStatementTr = model.ClosingStatementTr.Trim();
            f.ClosingStatementEn = model.ClosingStatementEn.Trim();
            f.AvailabilityTextTr = (model.AvailabilityTextTr ?? "").Trim();
            f.AvailabilityTextEn = (model.AvailabilityTextEn ?? "").Trim();
            f.IsAvailable = model.IsAvailable;
            f.TitleTr = model.TitleTr.Trim();
            f.TitleEn = model.TitleEn.Trim();
            f.DescriptionTr = (model.DescriptionTr ?? "").Trim();
            f.DescriptionEn = (model.DescriptionEn ?? "").Trim();
            f.ColophonTextTr = Clean(model.ColophonTextTr);
            f.ColophonTextEn = Clean(model.ColophonTextEn);
            f.ColophonNoteTr = Clean(model.ColophonNoteTr);
            f.ColophonNoteEn = Clean(model.ColophonNoteEn);
            f.CopyrightTextTr = (model.CopyrightTextTr ?? "").Trim();
            f.CopyrightTextEn = (model.CopyrightTextEn ?? "").Trim();
            f.LocationText = (model.LocationText ?? "").Trim();

            await _db.SaveChangesAsync();
            TempData["Success"] = "Footer kaydedildi.";
            return RedirectToAction(nameof(Index));
        }

        private static string? Clean(string? s) => string.IsNullOrWhiteSpace(s) ? null : s.Trim();
    }
}

