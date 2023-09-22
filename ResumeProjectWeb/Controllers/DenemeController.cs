using Core.Entities;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using PagedList;


namespace ResumeProjectWeb.Controllers
{
    public class DenemeController : Controller
    {
        private readonly IContactFormService _service;

        public DenemeController(IContactFormService service)
        {
            _service = service;
        }
        //bu sayfa deneme yaptığım sayfadır
        public async Task<IActionResult> Index(int page=1,int pageSize=3)
        {
            var values = await _service.GetAllAsync();
            PagedList<ContactForm> model = new PagedList<ContactForm>(values, page, pageSize);

            return View(model);
        }
    }
}
