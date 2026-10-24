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
    public class HeroController : Controller
    {
        private readonly AppDbContext _db;

        public HeroController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var hero = await _db.Heroes.AsNoTracking().FirstOrDefaultAsync();

            var model = hero == null
                ? new HeroEditViewModel()
                : new HeroEditViewModel
                {
                    HeadlineTr = hero.HeadlineTr,
                    HeadlineEn = hero.HeadlineEn,
                    SubtitleTr = hero.SubtitleTr,
                    SubtitleEn = hero.SubtitleEn,
                    ButtonTextTr = hero.ButtonTextTr,
                    ButtonTextEn = hero.ButtonTextEn
                };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(HeroEditViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var hero = await _db.Heroes.FirstOrDefaultAsync();
            if (hero == null)
            {
                hero = new Hero();
                _db.Heroes.Add(hero);
            }

            hero.HeadlineTr = model.HeadlineTr.Trim();
            hero.HeadlineEn = model.HeadlineEn.Trim();
            hero.SubtitleTr = model.SubtitleTr.Trim();
            hero.SubtitleEn = model.SubtitleEn.Trim();
            hero.ButtonTextTr = model.ButtonTextTr.Trim();
            hero.ButtonTextEn = model.ButtonTextEn.Trim();

            await _db.SaveChangesAsync();

            TempData["Success"] = "Ana sayfa içeriği kaydedildi.";
            return RedirectToAction(nameof(Index));
        }
    }
}