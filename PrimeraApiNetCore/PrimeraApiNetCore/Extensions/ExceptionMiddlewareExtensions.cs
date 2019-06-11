using PrimeraApiNetCore.Models;
//using LoggerService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Net;
using Microsoft.Extensions.Logging;
namespace PrimeraApiNetCore.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {

        //Al poner this delante de IApplicationBuilder se esta configurando como una extension
        //del tipo IApplicationBuilder de forma que las instancias de este tipo podran usar
        //el metodo de la forma     app.ConfigureExceptionHandler()

        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger<Startup> logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
 
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if(contextFeature != null)
                    { 
                        logger.LogError($"Something went wrong: {contextFeature.Error}");
 
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal Server Error."
                        }.ToString());
                    }
                });
            });
        } 
    }
}