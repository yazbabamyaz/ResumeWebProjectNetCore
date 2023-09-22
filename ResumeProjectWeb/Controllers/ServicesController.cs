using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Service.Exceptions;

namespace ResumeProjectWeb.Controllers
{
    public class ServicesController : Controller
    {
        private readonly IMyServiceService _myService;
        private readonly IMapper _mapper;



        public ServicesController(IMyServiceService myService, IMapper mapper)
        {
            _myService = myService;
            _mapper = mapper;

        }

        public async Task<IActionResult> Index()
        {
            var values = await _myService.GetAllAsync();
            return View(_mapper.Map<IEnumerable<MyServiceDto>>(values));
        }

        public async Task<IActionResult> DeleteService(int id)
        {
            //trycatch ten kurtulmak lazım
            // return await NewMethod(id);
            var entity = await _myService.GetByIdAsync(id);

            await _myService.RemoveAsync(entity);
            return RedirectToAction("Index");

        }

        private async Task<IActionResult> NewMethod(int id)
        {
            try
            {
                var entity = await _myService.GetByIdAsync(id);
                if (entity != null)
                {
                    await _myService.RemoveAsync(entity);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (NotFoundException ex)
            {
                TempData["error2"] = ex.Message;
                TempData["error"] = "Bir hata meydana geldi.";
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public async Task<IActionResult> UpdateService(int id)
        {
            try
            {

                var entity = await _myService.GetByIdAsync(id);

                return View(_mapper.Map<MyServiceDto>(entity));
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");
            }

        }
        [HttpPost]
        public async Task<IActionResult> UpdateService(MyServiceDto entityDto)
        {
            try
            {
                await _myService.UpdateAsync(_mapper.Map<MyService>(entityDto));
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");
            }

        }


        [HttpGet]
        public IActionResult AddService()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddService(MyServiceDto entityDto)
        {
            try
            {
                await _myService.AddAsync(_mapper.Map<MyService>(entityDto));
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");
            }

        }




    }
}
