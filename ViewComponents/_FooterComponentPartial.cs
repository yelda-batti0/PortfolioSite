using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioSite.DAL.Context;
using PortfolioSite.Helpers;
using PortfolioSite.ViewModels;
using System.Globalization;

namespace PortfolioSite.ViewComponents
{
    public class _FooterComponentPartial:ViewComponent
    {
        private readonly AppDbContext _db;

        public _FooterComponentPartial(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            bool en = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "en";

            var footer = await _db.Footers.AsNoTracking().FirstOrDefaultAsync();
            if (footer == null) return Content(string.Empty);

            var contact = await _db.Contacts.AsNoTracking().FirstOrDefaultAsync();

            var links = await _db.SocialMedias
                .AsNoTracking()
                .Where(x => x.IsActive)
                .OrderBy(x => x.SortOrder)
                .ToListAsync();

            var model = new FooterViewModel
            {
                ClosingStatementHtml = MarkupHelper.ToHtml(en ? footer.ClosingStatementEn : footer.ClosingStatementTr),
                AvailabilityText = en ? footer.AvailabilityTextEn : footer.AvailabilityTextTr,
                IsAvailable = footer.IsAvailable,
                Title = en ? footer.TitleEn : footer.TitleTr,
                Description = en ? footer.DescriptionEn : footer.DescriptionTr,
                ColophonText = (en ? footer.ColophonTextEn : footer.ColophonTextTr) ?? "",
                ColophonNote = (en ? footer.ColophonNoteEn : footer.ColophonNoteTr) ?? "",
                CopyrightText = en ? footer.CopyrightTextEn : footer.CopyrightTextTr,
                LocationText = footer.LocationText,
                Email = contact?.Email ?? "",
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
