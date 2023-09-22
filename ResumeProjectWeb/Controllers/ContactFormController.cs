using AutoMapper;
using Core.DTOs;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace ResumeProjectWeb.Controllers
{
    
    public class ContactFormController : Controller
    {
        private readonly IContactFormService _contactFormService;
        private readonly IMapper _mapper;

        public ContactFormController(IContactFormService contactFormService, IMapper mapper)
        {
            _contactFormService = contactFormService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values=await _contactFormService.GetAllAsync();

            return View(_mapper.Map<IEnumerable<ContactFormDto>>(values));
        }

        public async Task<IActionResult> DeleteMessage(int id) 
        { 
            var value=await _contactFormService.GetByIdAsync(id);
            await _contactFormService.RemoveAsync(value);
            return RedirectToAction("Index");   
        }
    }
}
