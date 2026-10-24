using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioSite.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace PortfolioSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MessageController : Controller
    {
        private readonly AppDbContext _db;

        public MessageController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _db.ContactMessages
                .AsNoTracking()
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var m = await _db.ContactMessages.FirstOrDefaultAsync(x => x.ContactMessageId == id);
            if (m == null) return NotFound();

            // Açılınca okundu olarak işaretle
            if (!m.IsRead)
            {
                m.IsRead = true;
                await _db.SaveChangesAsync();
            }
            return View(m);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkUnread(int id)
        {
            var m = await _db.ContactMessages.FirstOrDefaultAsync(x => x.ContactMessageId == id);
            if (m != null)
            {
                m.IsRead = false;
                await _db.SaveChangesAsync();
                TempData["Success"] = "Mesaj okunmadı olarak işaretlendi.";
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var m = await _db.ContactMessages.FirstOrDefaultAsync(x => x.ContactMessageId == id);
            if (m != null)
            {
                _db.ContactMessages.Remove(m);
                await _db.SaveChangesAsync();
                TempData["Success"] = "Mesaj silindi.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
