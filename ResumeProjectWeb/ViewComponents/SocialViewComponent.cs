using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ResumeProjectWeb.ViewComponents
{
    public class SocialViewComponent : ViewComponent
    {
        private readonly ISocialService _socialService;

        public SocialViewComponent(ISocialService socialService)
        {
            _socialService = socialService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _socialService.Where(x => x.Status == true).ToListAsync();
            return View(values);
        }
    }
}
