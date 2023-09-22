using Core.Entities;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace ResumeProjectWeb.ViewComponents
{
    public class ContactViewComponent : ViewComponent
    {
        private readonly IContactFormService _contactFormService;

        public ContactViewComponent(IContactFormService contactFormService)
        {
            _contactFormService = contactFormService;
        }

        public IViewComponentResult Invoke()
        {
            ContactForm contactForm = new ContactForm();

            return View(contactForm);
        }
    }
}
