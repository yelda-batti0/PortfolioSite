using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioSite.DAL.Context;
using PortfolioSite.DAL.Entities;
using PortfolioSite.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace PortfolioSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AboutController : Controller
    {
        private readonly AppDbContext _db;

        public AboutController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var a = await _db.Abouts.AsNoTracking().FirstOrDefaultAsync();

            var model = a == null
                ? new AboutEditViewModel()
                : new AboutEditViewModel
                {
                    HeaderLabelTr = a.HeaderLabelTr,
                    HeaderLabelEn = a.HeaderLabelEn,
                    TitleTr = a.TitleTr,
                    TitleEn = a.TitleEn,
                    BodyTr = a.BodyTr,
                    BodyEn = a.BodyEn,
                    TenetsTitleTr = a.TenetsTitleTr,
                    TenetsTitleEn = a.TenetsTitleEn,
                    TenetsTr = a.TenetsTr,
                    TenetsEn = a.TenetsEn,
                    FooterNoteTr = a.FooterNoteTr,
                    FooterNoteEn = a.FooterNoteEn
                };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(AboutEditViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var a = await _db.Abouts.FirstOrDefaultAsync();
            if (a == null)
            {
                a = new About();
                _db.Abouts.Add(a);
            }

            a.HeaderLabelTr = model.HeaderLabelTr.Trim();
            a.HeaderLabelEn = model.HeaderLabelEn.Trim();
            a.TitleTr = model.TitleTr.Trim();
            a.TitleEn = model.TitleEn.Trim();
            a.BodyTr = model.BodyTr.Trim();
            a.BodyEn = model.BodyEn.Trim();
            a.TenetsTitleTr = (model.TenetsTitleTr ?? "").Trim();
            a.TenetsTitleEn = (model.TenetsTitleEn ?? "").Trim();
            a.TenetsTr = (model.TenetsTr ?? "").Trim();
            a.TenetsEn = (model.TenetsEn ?? "").Trim();
            a.FooterNoteTr = (model.FooterNoteTr ?? "").Trim();
            a.FooterNoteEn = (model.FooterNoteEn ?? "").Trim();

            await _db.SaveChangesAsync();

            TempData["Success"] = "Hakkımda içeriği kaydedildi.";
            return RedirectToAction(nameof(Index));
        }
    }
}
