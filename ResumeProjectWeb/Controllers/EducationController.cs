using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using ResumeProjectWeb.Filters;

namespace ResumeProjectWeb.Controllers
{
    public class EducationController : Controller
    {
        private readonly IEducationService _educationService;
        private readonly IMapper _mapper;

        public EducationController(IEducationService educationService, IMapper mapper)
        {
            _educationService = educationService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _educationService.GetAllAsync();

            return View(_mapper.Map<IEnumerable<EducationDto>>(values));
        }

        public async Task<IActionResult> DeleteEducation(int id)
        {

            var entity = await _educationService.GetByIdAsync(id);
            await _educationService.RemoveAsync(entity);
            return RedirectToAction("Index");
        }


        [ParameterControl]
        [HttpGet]
        public async Task<IActionResult> UpdateEducation(int id)
        {
            
                var entity = await _educationService.GetByIdAsync(id);
                return View(_mapper.Map<EducationDto>(entity));          
           
                //TempData["error"] = ex.Message;
                //return RedirectToAction("Index");
           

        }
        [HttpPost]
        public async Task<IActionResult> UpdateEducation(EducationDto entityDto)
        {
            try
            {

                await _educationService.UpdateAsync(_mapper.Map<Education>(entityDto));
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");
            }

        }

        [HttpGet]
        public IActionResult AddEducation()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddEducation(EducationDto entityDto)
        {
            await _educationService.AddAsync(_mapper.Map<Education>(entityDto));
            return RedirectToAction("Index");
        }
    }
}
