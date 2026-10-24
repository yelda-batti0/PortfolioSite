using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioSite.DAL.Context;
using PortfolioSite.ViewModels;
using System.Globalization;

namespace PortfolioSite.ViewComponents
{
    public class _ProjectComponentPartial:ViewComponent
    {
        private readonly AppDbContext _db;

        public _ProjectComponentPartial(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            bool en = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "en";

            var setting = await _db.SiteSettings.AsNoTracking().FirstOrDefaultAsync();

            var projects = await _db.Projects
                .AsNoTracking()
                .Where(x => x.IsPublished)
                .OrderBy(x => x.SortOrder)
                .ToListAsync();

            if (setting == null && projects.Count == 0)
                return Content(string.Empty);

            var model = new ProjectsViewModel
            {
                Label = setting == null ? "" : (en ? setting.ProjectsLabelEn : setting.ProjectsLabelTr),
                DateRange = setting?.ProjectsDateRange ?? "",
                Items = projects.Select(p => new ProjectItemViewModel
                {
                    CardType = p.CardType,
                    Title = en ? p.TitleEn : p.TitleTr,
                    Subtitle = en ? p.SubtitleEn : p.SubtitleTr,
                    Description = en ? p.DescriptionEn : p.DescriptionTr,
                    Technologies = (p.Technologies ?? "")
                        .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                        .ToList(),
                    CategoryLabel = (en ? p.CategoryLabelEn : p.CategoryLabelTr) ?? "",
                    FooterNote = (en ? p.FooterNoteEn : p.FooterNoteTr) ?? "",
                    ImagePath = p.ImagePath,
                    PrimaryButtonText = (en ? p.PrimaryButtonTextEn : p.PrimaryButtonTextTr) ?? "",
                    PrimaryButtonUrl = p.PrimaryButtonUrl,
                    SecondaryButtonText = (en ? p.SecondaryButtonTextEn : p.SecondaryButtonTextTr) ?? "",
                    SecondaryButtonUrl = p.SecondaryButtonUrl,
                    CodeFileName = p.CodeFileName,
                    CodeBadge = p.CodeBadge,
                    CodeSnippet = p.CodeSnippet
                }).ToList()
            };

            return View(model);
        }
    }
}
