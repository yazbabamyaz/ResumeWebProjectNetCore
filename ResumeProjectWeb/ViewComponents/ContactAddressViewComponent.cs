using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace ResumeProjectWeb.ViewComponents
{
    public class ContactAddressViewComponent : ViewComponent
    {
        private readonly IContactAddressService _contactAddressService;

        public ContactAddressViewComponent(IContactAddressService contactAddressService)
        {
            _contactAddressService = contactAddressService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _contactAddressService.GetAllAsync();
            return View(values);
        }
    }
}
