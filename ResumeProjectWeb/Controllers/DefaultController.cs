using Core.Entities;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ResumeProjectWeb.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly IContactFormService _contactFormService;

        public DefaultController(IAboutService aboutService, IContactFormService contactFormService)
        {
            _aboutService = aboutService;
            _contactFormService = contactFormService;
        }

        //[HttpGet]
        public async Task<IActionResult> Index()
        {
            var about = await _aboutService.GetAllAsync();

            return View(about);
        }
        [HttpPost]
        public IActionResult MessagePost(ContactForm entity)
        {
            entity.Date = DateTime.Now;
            _contactFormService.AddAsync(entity);
            return RedirectToAction("Index");
        }

        //[HttpGet]
        //public PartialViewResult AddComment()
        //{
        //    return PartialView();
        //}
        //[HttpPost]
        //public IActionResult AddComment(Comment comment)
        //{
        //    comment.CommentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        //    comment.CommentState = true;

        //    _commentService.TAdd(comment);
        //    return RedirectToAction("Index", "Destination");
        //}
    }
}
