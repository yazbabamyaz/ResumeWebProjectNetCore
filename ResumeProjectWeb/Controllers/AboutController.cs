using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace ResumeProjectWeb.Controllers
{
    //[AllowAnonymous]

    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _aboutService.GetByIdAsync(1);//Tek Kişiye Ait Cv

            return View(_mapper.Map<AboutDto>(values));
        }
        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file, AboutDto entityDto)
        {


            if (file != null)
            {
                string imageExtension = Path.GetExtension(file.FileName);

                string imageName = Guid.NewGuid() + imageExtension;

                string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/Admin/images/{imageName}");

                using var stream = new FileStream(path, FileMode.Create);

                await file.CopyToAsync(stream);

                entityDto.Image = imageName;
                await _aboutService.UpdateAsync(_mapper.Map<About>(entityDto));
                TempData["status"] = "Veriler Güncellendi.";

            }

            return RedirectToAction("Index");
        }
    }
}
