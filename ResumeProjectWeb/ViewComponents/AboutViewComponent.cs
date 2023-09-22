using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace ResumeProjectWeb.ViewComponents
{
    public class AboutViewComponent : ViewComponent
    {
        private readonly IAboutService _aboutService;

        public AboutViewComponent(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var about = await _aboutService.GetAllAsync();
            return View(about);
        }
    }
}
