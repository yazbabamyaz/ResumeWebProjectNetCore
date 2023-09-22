using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace ResumeProjectWeb.ViewComponents
{
    public class WorkViewComponent : ViewComponent
    {
        private readonly IWorkService _workService;

        public WorkViewComponent(IWorkService workService)
        {
            _workService = workService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _workService.GetAllAsync();
            return View(values);
        }
    }
}
