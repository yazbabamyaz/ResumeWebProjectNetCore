using Core.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Service.Exceptions;
using System;

namespace ResumeProjectWeb.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error")]
        public IActionResult Error()
        {
            //var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();           
            //ViewBag.ErrorMessage = exceptionDetails.Error.Message;
            //ViewBag.ErrorCode= HttpContext.Response.StatusCode;
            //return View("Error");


            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exceptionMessage = exceptionDetails.Error.Message;
            var problemDetails=new ProblemDetails()
            {   
                Status=StatusCodes.Status500InternalServerError,
                Title=$"Beklenmeyen bir hata meydana geldi.{exceptionDetails.Error}",
                Detail=exceptionMessage
            };

            if (exceptionDetails.Error is NotFoundException)
            {
                problemDetails.Status = StatusCodes.Status404NotFound;
                problemDetails.Title = "Resource not found";
            }
            //if (exceptionDetails.Error is)
            //{
            //    problemDetails.Status = StatusCodes.Status404NotFound;
            //    problemDetails.Title = "Resource not found";
            //}

            return View(problemDetails);
            //return StatusCode(StatusCodes.Status404NotFound, exceptionDetails);

        }

        [AllowAnonymous]
        public IActionResult ErrorPage(int code)
        {
            return View();
        }

        public IActionResult NoParameter(ErrrorViewModel errrorViewModel) 
        {
            return View(errrorViewModel);
        }
    }
}
