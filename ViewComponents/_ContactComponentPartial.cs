using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioSite.DAL.Context;
using PortfolioSite.ViewModels;
using System.Globalization;

namespace PortfolioSite.ViewComponents
{
    public class _ContactComponentPartial:ViewComponent
    {
        private readonly AppDbContext _db;

        public _ContactComponentPartial(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            bool en = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "en";

            var contact = await _db.Contacts.AsNoTracking().FirstOrDefaultAsync();
            if (contact == null) return Content(string.Empty);

            var topics = await _db.ContactTopics
                .AsNoTracking()
                .Where(x => x.IsActive)
                .OrderBy(x => x.SortOrder)
                .ToListAsync();

            var model = new ContactViewModel
            {
                HeaderLabel = en ? contact.HeaderLabelEn : contact.HeaderLabelTr,
                Title = en ? contact.TitleEn : contact.TitleTr,
                TitleAccent = en ? contact.TitleAccentEn : contact.TitleAccentTr,
                Description = en ? contact.DescriptionEn : contact.DescriptionTr,
                ResponseNote = en ? contact.ResponseNotEn : contact.ResponseNotTr,
                Email = contact.Email,
                Topics = topics.Select(t => en ? t.NameEn : t.NameTr).ToList()
            };

            return View(model);
        }
    }
}
