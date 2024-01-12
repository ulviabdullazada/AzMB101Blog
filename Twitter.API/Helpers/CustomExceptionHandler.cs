using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Twitter.Business.Exceptions;
using Twitter.Business.Exceptions.Common;
using Twitter.Core.Entities;

namespace Twitter.API.Helpers
{
    public static class CustomExceptionHandler
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this WebApplication app)
        {
            app.UseExceptionHandler(opt =>
            {
                opt.Run(async context =>
                {
                    var feature = context.Features.Get<IExceptionHandlerFeature>();
                    var exception = feature.Error;
                    if (exception is IBaseException ex)
                    {
                        await context.Response.WriteAsJsonAsync(new
                        {
                            StatusCode = ex.StatusCode,
                            Message = ex.ErrorMessage
                        });
                    }
                    else if (exception is ArgumentException)
                    {
                        await context.Response.WriteAsJsonAsync(new
                        {
                            StatusCode = StatusCodes.Status400BadRequest,
                            Message = "Problem in arguments"
                        });
                    }
                    else if(exception is Exception exc)
                    {
                        await context.Response.WriteAsJsonAsync(new
                        {
                            StatusCode = StatusCodes.Status500InternalServerError,
                            Message = exc.Message
                        });
                    }
                });
            });
            return app;
        }
    }
}
