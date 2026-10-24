using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioSite.DAL.Context;
using PortfolioSite.DAL.Entities;
using PortfolioSite.Helpers;
using PortfolioSite.ViewModels;
using Microsoft.EntityFrameworkCore;
namespace PortfolioSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SiteSettingController : Controller
    {
        private readonly AppDbContext _db;
        private readonly ImageUploader _uploader;

        public SiteSettingController(AppDbContext db, ImageUploader uploader)
        {
            _db = db;
            _uploader = uploader;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var s = await _db.SiteSettings.AsNoTracking().FirstOrDefaultAsync();
            var model = s == null ? new SiteSettingEditViewModel() : new SiteSettingEditViewModel
            {
                ProjectsLabelTr = s.ProjectsLabelTr,
                ProjectsLabelEn = s.ProjectsLabelEn,
                ProjectsDateRange = s.ProjectsDateRange,
                SkillsLabelTr = s.SkillsLabelTr,
                SkillsLabelEn = s.SkillsLabelEn,
                SkillsTitleTr = s.SkillsTitleTr,
                SkillsTitleEn = s.SkillsTitleEn,
                SkillsSideNoteTr = s.SkillsSideNoteTr,
                SkillsSideNoteEn = s.SkillsSideNoteEn,
                CvPath = s.CvPath
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequestSizeLimit(6 * 1024 * 1024)]
        public async Task<IActionResult> Index(SiteSettingEditViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var s = await _db.SiteSettings.FirstOrDefaultAsync();
            if (s == null)
            {
                s = new SiteSetting { SiteName = "Portfolyo" };
                _db.SiteSettings.Add(s);
            }

            string? oldCv = s.CvPath;
            if (model.CvFile != null && model.CvFile.Length > 0)
            {
                var (path, error) = await _uploader.SavePdfAsync(model.CvFile, "cv");
                if (error != null)
                {
                    ModelState.AddModelError(nameof(model.CvFile), error);
                    model.CvPath = oldCv;
                    return View(model);
                }
                s.CvPath = path;
                _uploader.Delete(oldCv);
            }
            else if (model.RemoveCv)
            {
                s.CvPath = null;
                _uploader.Delete(oldCv);
            }

            s.ProjectsLabelTr = model.ProjectsLabelTr.Trim();
            s.ProjectsLabelEn = model.ProjectsLabelEn.Trim();
            s.ProjectsDateRange = (model.ProjectsDateRange ?? "").Trim();
            s.SkillsLabelTr = (model.SkillsLabelTr ?? "").Trim();
            s.SkillsLabelEn = (model.SkillsLabelEn ?? "").Trim();
            s.SkillsTitleTr = (model.SkillsTitleTr ?? "").Trim();
            s.SkillsTitleEn = (model.SkillsTitleEn ?? "").Trim();
            s.SkillsSideNoteTr = (model.SkillsSideNoteTr ?? "").Trim();
            s.SkillsSideNoteEn = (model.SkillsSideNoteEn ?? "").Trim();

            await _db.SaveChangesAsync();
            TempData["Success"] = "Site ayarları kaydedildi.";
            return RedirectToAction(nameof(Index));
        }
    }
}
