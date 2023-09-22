using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Service.Services;

namespace ResumeProjectWeb.Controllers
{
    public class ContactAddressController : Controller
    {
        private readonly IContactAddressService _contactAddressService;
        private readonly IMapper _mapper;

        public ContactAddressController(IContactAddressService contactAddressService, IMapper mapper)
        {
            _contactAddressService = contactAddressService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _contactAddressService.GetAllAsync();
            

            return View(_mapper.Map<IEnumerable<ContactAddressDto>>(values));
           
        }

        public async Task<IActionResult> DeleteContact(int id)
        {
            var value = await _contactAddressService.GetByIdAsync(id);
            await _contactAddressService.RemoveAsync(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateContact(int id)
        {
            var value = await _contactAddressService.GetByIdAsync(id);

            return View(_mapper.Map<ContactAddressDto>(value));            
        }
        [HttpPost]
        public async Task<IActionResult> UpdateContact(ContactAddressDto contactAddressDto)
        {
            var value = _mapper.Map<ContactAddress>(contactAddressDto);
            await _contactAddressService.UpdateAsync(value);
            return RedirectToAction("Index");

        }
    }
}
