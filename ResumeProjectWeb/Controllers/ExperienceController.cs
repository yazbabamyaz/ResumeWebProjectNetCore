using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Service.Services;

namespace ResumeProjectWeb.Controllers
{
    public class ExperienceController : Controller
    {
        private readonly IExperienceService _experienceService;
        private readonly IMapper _mapper;

        public ExperienceController(IExperienceService experienceService, IMapper mapper)
        {
            _experienceService = experienceService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values= await _experienceService.GetAllAsync();

            return View(_mapper.Map<IEnumerable<ExperienceDto>>(values));
        }

        public async Task<IActionResult> DeleteExperience(int id)
        {
            var entity = await _experienceService.GetByIdAsync(id);
            await _experienceService.RemoveAsync(entity);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateExperience(int id)
        {
            try
            {
                var entity = await _experienceService.GetByIdAsync(id);

                return View(_mapper.Map<ExperienceDto>(entity));
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateExperience(ExperienceDto entityDto)
        {
            try
            {
                await _experienceService.UpdateAsync(_mapper.Map<Experience>(entityDto));
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");
            }

        }

        [HttpGet]
        public IActionResult AddExperience()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddExperience(ExperienceDto entityDto)
        {
            await _experienceService.AddAsync(_mapper.Map<Experience>(entityDto));
            return RedirectToAction("Index");
        }

    }
}
