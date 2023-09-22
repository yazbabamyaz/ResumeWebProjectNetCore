using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace ResumeProjectWeb.ViewComponents
{
    public class ExperienceViewComponent : ViewComponent
    {
        private readonly IExperienceService _experienceService;

        public ExperienceViewComponent(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _experienceService.GetAllAsync();
            return View(values);
        }
    }
}
