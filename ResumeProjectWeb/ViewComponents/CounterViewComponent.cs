using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace ResumeProjectWeb.ViewComponents
{
    public class CounterViewComponent : ViewComponent
    {
        private readonly IWorkService _workService;

        public CounterViewComponent(IWorkService workService)
        {
            _workService = workService;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.CompletedProject = _workService.Where(x => x.ProjectStatus == true).Count();
            ViewBag.WorkingProject = _workService.Where(x => x.ProjectStatus == false).Count();
            ViewBag.AwardProject = _workService.Where(x => x.ProjectAward == true).Count();

            return View();
        }
    }
}
