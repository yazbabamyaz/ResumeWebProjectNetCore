using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace ResumeProjectWeb.ViewComponents
{
    public class MyServiceViewComponent : ViewComponent
    {

        private readonly IMyServiceService _myServiceService;

        public MyServiceViewComponent(IMyServiceService myServiceService)
        {
            _myServiceService = myServiceService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _myServiceService.GetAllAsync();
            return View(values);
        }
    }
}
