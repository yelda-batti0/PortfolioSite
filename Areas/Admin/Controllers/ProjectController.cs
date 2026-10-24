using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioSite.DAL.Context;
using PortfolioSite.DAL.Entities;
using PortfolioSite.Helpers;
using PortfolioSite.ViewModels;

namespace PortfolioSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ProjectController : Controller
    {
        private readonly AppDbContext _db;
        private readonly ImageUploader _uploader;

        public ProjectController(AppDbContext db, ImageUploader uploader)
        {
            _db = db;
            _uploader = uploader;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _db.Projects.AsNoTracking().OrderBy(x => x.SortOrder).ToListAsync();
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var next = (_db.Projects.Max(x => (int?)x.SortOrder) ?? 0) + 1;
            return View("Edit", new ProjectEditViewModel { SortOrder = next });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var p = await _db.Projects.AsNoTracking().FirstOrDefaultAsync(x => x.ProjectId == id);
            if (p == null) return NotFound();

            return View(new ProjectEditViewModel
            {
                ProjectId = p.ProjectId,
                CardType = p.CardType,
                TitleTr = p.TitleTr,
                TitleEn = p.TitleEn,
                SubtitleTr = p.SubtitleTr,
                SubtitleEn = p.SubtitleEn,
                DescriptionTr = p.DescriptionTr,
                DescriptionEn = p.DescriptionEn,
                Technologies = p.Technologies,
                CategoryLabelTr = p.CategoryLabelTr,
                CategoryLabelEn = p.CategoryLabelEn,
                FooterNoteTr = p.FooterNoteTr,
                FooterNoteEn = p.FooterNoteEn,
                PrimaryButtonTextTr = p.PrimaryButtonTextTr,
                PrimaryButtonTextEn = p.PrimaryButtonTextEn,
                PrimaryButtonUrl = p.PrimaryButtonUrl,
                SecondaryButtonTextTr = p.SecondaryButtonTextTr,
                SecondaryButtonTextEn = p.SecondaryButtonTextEn,
                SecondaryButtonUrl = p.SecondaryButtonUrl,
                CodeFileName = p.CodeFileName,
                CodeBadge = p.CodeBadge,
                CodeSnippet = p.CodeSnippet,
                ImagePath = p.ImagePath,
                SortOrder = p.SortOrder,
                IsPublished = p.IsPublished
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequestSizeLimit(6 * 1024 * 1024)]
        public async Task<IActionResult> Save(ProjectEditViewModel model)
        {
            // Link güvenliği: sadece http/https (javascript: gibi şemalar reddedilir)
            ValidateUrl(nameof(model.PrimaryButtonUrl), model.PrimaryButtonUrl);
            ValidateUrl(nameof(model.SecondaryButtonUrl), model.SecondaryButtonUrl);

            if (!ModelState.IsValid)
                return View("Edit", model);

            Project? p;
            if (model.ProjectId == 0)
            {
                p = new Project { CreatedAt = DateTime.UtcNow };
                _db.Projects.Add(p);
            }
            else
            {
                p = await _db.Projects.FirstOrDefaultAsync(x => x.ProjectId == model.ProjectId);
                if (p == null) return NotFound();
            }

            // Görsel işlemleri
            string? oldImage = p.ImagePath;
            if (model.ImageFile != null && model.ImageFile.Length > 0)
            {
                var (path, error) = await _uploader.SaveAsync(model.ImageFile, "projects");
                if (error != null)
                {
                    ModelState.AddModelError(nameof(model.ImageFile), error);
                    model.ImagePath = oldImage;
                    return View("Edit", model);
                }
                p.ImagePath = path;
                _uploader.Delete(oldImage);
            }
            else if (model.RemoveImage)
            {
                p.ImagePath = null;
                _uploader.Delete(oldImage);
            }

            p.CardType = model.CardType;
            p.TitleTr = model.TitleTr.Trim();
            p.TitleEn = model.TitleEn.Trim();
            p.SubtitleTr = (model.SubtitleTr ?? "").Trim();
            p.SubtitleEn = (model.SubtitleEn ?? "").Trim();
            p.DescriptionTr = model.DescriptionTr.Trim();
            p.DescriptionEn = model.DescriptionEn.Trim();
            p.Technologies = (model.Technologies ?? "").Trim();
            p.CategoryLabelTr = Clean(model.CategoryLabelTr);
            p.CategoryLabelEn = Clean(model.CategoryLabelEn);
            p.FooterNoteTr = Clean(model.FooterNoteTr);
            p.FooterNoteEn = Clean(model.FooterNoteEn);
            p.PrimaryButtonTextTr = Clean(model.PrimaryButtonTextTr);
            p.PrimaryButtonTextEn = Clean(model.PrimaryButtonTextEn);
            p.PrimaryButtonUrl = Clean(model.PrimaryButtonUrl);
            p.SecondaryButtonTextTr = Clean(model.SecondaryButtonTextTr);
            p.SecondaryButtonTextEn = Clean(model.SecondaryButtonTextEn);
            p.SecondaryButtonUrl = Clean(model.SecondaryButtonUrl);
            p.CodeFileName = Clean(model.CodeFileName);
            p.CodeBadge = Clean(model.CodeBadge);
            p.CodeSnippet = string.IsNullOrWhiteSpace(model.CodeSnippet) ? null : model.CodeSnippet;
            p.SortOrder = model.SortOrder;
            p.IsPublished = model.IsPublished;

            await _db.SaveChangesAsync();

            TempData["Success"] = "Proje kaydedildi.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var p = await _db.Projects.FirstOrDefaultAsync(x => x.ProjectId == id);
            if (p != null)
            {
                _uploader.Delete(p.ImagePath);
                _db.Projects.Remove(p);
                await _db.SaveChangesAsync();
                TempData["Success"] = "Proje silindi.";
            }
            return RedirectToAction(nameof(Index));
        }

        private static string? Clean(string? s) => string.IsNullOrWhiteSpace(s) ? null : s.Trim();

        private void ValidateUrl(string field, string? url)
        {
            if (string.IsNullOrWhiteSpace(url)) return;
            if (!Uri.TryCreate(url.Trim(), UriKind.Absolute, out var uri)
                || (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps))
                ModelState.AddModelError(field, "Link http:// veya https:// ile başlamalı.");
        }
    }
}
