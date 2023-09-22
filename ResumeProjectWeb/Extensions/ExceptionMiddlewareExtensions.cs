using Core.ErrorModel;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Service.Exceptions;

namespace ResumeProjectWeb.Extensions
{
    //deneme için kullandığım kodlar.
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this WebApplication app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    //context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;//500
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();//hata var mı
                    //context in IExceptionHandlerFeature böyle bir özelliği varsa demek ki hata var 
                    if (contextFeature is not null)//hata varsa
                    {

                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            NotFoundException => StatusCodes.Status404NotFound,
                            _ => StatusCodes.Status500InternalServerError
                        };

                        //var values= new ErrorDetails()
                        //{
                        //    Message = contextFeature.Error.Message,
                        //    StatusCode = context.Response.StatusCode
                        //};
                        //return values;



                       


                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message
                        }.ToString());
                    }
                });
            });
        }
    }
}
