using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioSite.DAL.Context;
using PortfolioSite.Helpers;
using PortfolioSite.ViewModels;
using System.Globalization;

namespace PortfolioSite.ViewComponents
{
    public class _SkillComponentPartial:ViewComponent
    {
        private readonly AppDbContext _db;

        public _SkillComponentPartial(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            bool en = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "en";

            var setting = await _db.SiteSettings.AsNoTracking().FirstOrDefaultAsync();

            var categories = await _db.Skills
                .AsNoTracking()
                .Where(x => x.IsActive)
                .OrderBy(x => x.SortOrder)
                .ToListAsync();

            if (setting == null && categories.Count == 0)
                return Content(string.Empty);

            var model = new SkillsViewModel
            {
                Label = setting == null ? "" : (en ? setting.SkillsLabelEn : setting.SkillsLabelTr),
                TitleHtml = setting == null ? "" : MarkupHelper.ToHtml(en ? setting.SkillsTitleEn : setting.SkillsTitleTr),
                SideNote = setting == null ? "" : (en ? setting.SkillsSideNoteEn : setting.SkillsSideNoteTr),
                Items = categories.Select(c => new SkillItemViewModel
                {
                    Name = en ? c.NameEn : c.NameTr,
                    MainLine = en ? c.MainLineEn : c.MainLineTr,
                    Detail = en ? c.DetailEn : c.DetailTr,
                    Badge = en ? c.BadgeEn : c.BadgeTr,
                    IconKey = c.IconKey
                }).ToList()
            };

            return View(model);
        }
    }
}
