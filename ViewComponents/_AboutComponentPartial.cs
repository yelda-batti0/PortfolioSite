using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioSite.DAL.Context;
using PortfolioSite.ViewModels;

namespace PortfolioSite.ViewComponents
{
    public class _AboutComponentPartial : ViewComponent
    {
        private readonly AppDbContext _db;

        public _AboutComponentPartial(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            bool en = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "en";

            var about = await _db.Abouts.AsNoTracking().FirstOrDefaultAsync();
            if (about == null) return Content(string.Empty);

            var links = await _db.SocialMedias
                .AsNoTracking()
                .Where(x => x.IsActive)
                .OrderBy(x => x.SortOrder)
                .ToListAsync();

            string body = (en ? about.BodyEn : about.BodyTr) ?? "";
            string tenets = (en ? about.TenetsEn : about.TenetsTr) ?? "";
            var cvPath = (await _db.SiteSettings.AsNoTracking().FirstOrDefaultAsync())?.CvPath;

            var model = new AboutViewModel
            {
                HeaderLabel = en ? about.HeaderLabelEn : about.HeaderLabelTr,
                Title = en ? about.TitleEn : about.TitleTr,
                Paragraphs = body
                    .Replace("\r\n", "\n")
                    .Split("\n\n", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                    .ToList(),
                TenetsTitle = en ? about.TenetsTitleEn : about.TenetsTitleTr,
                Tenets = tenets
                    .Replace("\r\n", "\n")
                    .Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                    .ToList(),
                FooterNote = en ? about.FooterNoteEn : about.FooterNoteTr,
                CvPath = cvPath,
                SocialLinks = links.Select(l => new SocialLinkViewModel
                {
                    Title = l.Title,
                    Url = l.Url
                }).ToList()
            };

            return View(model);
        }
    }
}