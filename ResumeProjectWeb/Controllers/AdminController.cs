using Microsoft.AspNetCore.Mvc;

namespace ResumeProjectWeb.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
