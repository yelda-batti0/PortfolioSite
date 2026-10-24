using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioSite.DAL.Context;

namespace PortfolioSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly AppDbContext _db;

        public DashboardController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.ProjectCount = await _db.Projects.CountAsync();
            ViewBag.SkillCount = await _db.Skills.CountAsync();
            ViewBag.MessageCount = await _db.ContactMessages.CountAsync();
            ViewBag.UnreadCount = await _db.ContactMessages.CountAsync(x => !x.IsRead);
            return View();
        }
    }
}