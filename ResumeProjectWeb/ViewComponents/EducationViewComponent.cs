using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace ResumeProjectWeb.ViewComponents
{
    public class EducationViewComponent : ViewComponent
    {

        private readonly IEducationService _educationService;

        public EducationViewComponent(IEducationService educationService)
        {
            _educationService = educationService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var about = await _educationService.GetAllAsync();
            return View(about);
        }

    }
}
