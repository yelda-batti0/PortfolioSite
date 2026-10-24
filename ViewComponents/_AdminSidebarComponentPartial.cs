using Microsoft.AspNetCore.Mvc;
using PortfolioSite.DAL.Context;
using PortfolioSite.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace PortfolioSite.ViewComponents
{
    public class _AdminSidebarComponentPartial:ViewComponent
    {
        private readonly AppDbContext _db;

        public _AdminSidebarComponentPartial(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new AdminSidebarViewModel
            {
                Email = UserClaimsPrincipal.Identity?.Name ?? "",
                UnreadMessages = await _db.ContactMessages.CountAsync(x => !x.IsRead),
                CurrentController = RouteData.Values["controller"]?.ToString() ?? ""
            };

            return View(model);
        }
    }

}
