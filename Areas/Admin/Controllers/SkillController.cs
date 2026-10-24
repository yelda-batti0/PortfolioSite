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
    public class SkillController : Controller
    {
        private static readonly string[] AllowedIcons = { "backend", "database", "network", "code" };
        private readonly AppDbContext _db;

        public SkillController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _db.Skills.AsNoTracking().OrderBy(x => x.SortOrder).ToListAsync();
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var next = (_db.Skills.Max(x => (int?)x.SortOrder) ?? 0) + 1;
            return View("Edit", new SkillEditViewModel { SortOrder = next });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var s = await _db.Skills.AsNoTracking().FirstOrDefaultAsync(x => x.SkillId == id);
            if (s == null) return NotFound();

            return View(new SkillEditViewModel
            {
                SkillId = s.SkillId,
                NameTr = s.NameTr,
                NameEn = s.NameEn,
                MainLineTr = s.MainLineTr,
                MainLineEn = s.MainLineEn,
                DetailTr = s.DetailTr,
                DetailEn = s.DetailEn,
                BadgeTr = s.BadgeTr,
                BadgeEn = s.BadgeEn,
                IconKey = s.IconKey,
                SortOrder = s.SortOrder,
                IsActive = s.IsActive
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(SkillEditViewModel model)
        {
            if (!string.IsNullOrEmpty(model.IconKey) && !AllowedIcons.Contains(model.IconKey))
                ModelState.AddModelError(nameof(model.IconKey), "Geçersiz simge.");

            if (!ModelState.IsValid)
                return View("Edit", model);

            Skill? s;
            if (model.SkillId == 0)
            {
                s = new Skill();
                _db.Skills.Add(s);
            }
            else
            {
                s = await _db.Skills.FirstOrDefaultAsync(x => x.SkillId == model.SkillId);
                if (s == null) return NotFound();
            }

            s.NameTr = model.NameTr.Trim();
            s.NameEn = model.NameEn.Trim();
            s.MainLineTr = model.MainLineTr.Trim();
            s.MainLineEn = model.MainLineEn.Trim();
            s.DetailTr = (model.DetailTr ?? "").Trim();
            s.DetailEn = (model.DetailEn ?? "").Trim();
            s.BadgeTr = (model.BadgeTr ?? "").Trim();
            s.BadgeEn = (model.BadgeEn ?? "").Trim();
            s.IconKey = string.IsNullOrEmpty(model.IconKey) ? null : model.IconKey;
            s.SortOrder = model.SortOrder;
            s.IsActive = model.IsActive;

            await _db.SaveChangesAsync();

            TempData["Success"] = "Yetenek kaydedildi.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var s = await _db.Skills.FirstOrDefaultAsync(x => x.SkillId == id);
            if (s != null)
            {
                _db.Skills.Remove(s);
                await _db.SaveChangesAsync();
                TempData["Success"] = "Yetenek silindi.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
