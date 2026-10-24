using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioSite.DAL.Context;
using PortfolioSite.Helpers;
using PortfolioSite.ViewModels;
using System.Globalization;

namespace PortfolioSite.ViewComponents
{
    public class _HeroComponentPartial:ViewComponent
    {
        private readonly AppDbContext _db;

        public _HeroComponentPartial(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var hero = await _db.Heroes.AsNoTracking().FirstOrDefaultAsync();
            if (hero == null) return Content(string.Empty);

            bool en = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "en";

            var model = new HeroViewModel
            {
                HeadlineHtml = MarkupHelper.ToHtml(en ? hero.HeadlineEn : hero.HeadlineTr),
                Subtitle = en ? hero.SubtitleEn : hero.SubtitleTr,
                ButtonText = en ? hero.ButtonTextEn : hero.ButtonTextTr
            };

            return View(model);
        }
    }
}
