using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Service.Services;

namespace ResumeProjectWeb.Controllers
{
    public class WorkController : Controller
    {
        private readonly IWorkService _workService;
        private readonly IMapper _mapper;

        public WorkController(IWorkService workService, IMapper mapper)
        {
            _workService = workService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values=await _workService.GetAllAsync();

            return View(_mapper.Map<IEnumerable<WorkDto>>(values));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateWork(int id) 
        {
            var value=await _workService.GetByIdAsync(id);
            _workService.UpdateAsync(value);
            return View(_mapper.Map<WorkDto>(value));

        }

        [HttpPost]
        public async Task<IActionResult> UpdateWork(IFormFile file, WorkDto workDto)
        {

            if (file != null)
            {
                string imageExtension = Path.GetExtension(file.FileName);

                string imageName = Guid.NewGuid() + imageExtension;

                string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/Admin/images/work/{imageName}");

                using var stream = new FileStream(path, FileMode.Create);

                await file.CopyToAsync(stream);

                workDto.Image = imageName;
                await _workService.UpdateAsync(_mapper.Map<Work>(workDto));
                TempData["status"] = "Veriler Güncellendi.";
                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteWork(int id)
        {
            var entity=await _workService.GetByIdAsync(id);
           await _workService.RemoveAsync(entity);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public  IActionResult AddWork()
        {            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddWork(IFormFile file, WorkDto workDto)
        {

            if (file != null)
            {
                string imageExtension = Path.GetExtension(file.FileName);

                string imageName = Guid.NewGuid() + imageExtension;

                string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/Admin/images/work/{imageName}");

                using var stream = new FileStream(path, FileMode.Create);

                await file.CopyToAsync(stream);

                workDto.Image = imageName;
                await _workService.AddAsync(_mapper.Map<Work>(workDto));
                TempData["status"] = "Veriler Eklendi.";
                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
        }

    }
}
