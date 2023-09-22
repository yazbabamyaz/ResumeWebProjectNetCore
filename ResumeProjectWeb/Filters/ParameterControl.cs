using Core.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ResumeProjectWeb.Models;
using static System.Net.Mime.MediaTypeNames;

namespace ResumeProjectWeb.Filters
{
    public class ParameterControl : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var idValue = context.ActionArguments.Values.FirstOrDefault();
            if (idValue == null)
            {
                //apiden farkı burada error sayfaya yönlendircez.
                var errorViewModel = new Core.DTOs.ErrrorViewModel();
                errorViewModel.Errors.Add("Parametre hatası.");

                context.Result = new RedirectToActionResult("NoParameter", "Error", errorViewModel);
            }
            
        }
    }
}
