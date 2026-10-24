using Microsoft.AspNetCore.Mvc;

namespace PortfolioSite.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("Error")]
        public IActionResult Error()
        {
            Response.StatusCode = 500;
            return View("Error");
        }

        [Route("Error/{code:int}")]
        public IActionResult StatusPage(int code)
        {
            Response.StatusCode = code;
            return View(code == 404 ? "NotFound" : "Error");
        }
    }
}