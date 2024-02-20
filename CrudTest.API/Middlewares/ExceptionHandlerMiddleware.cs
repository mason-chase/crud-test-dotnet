using CrudTest.Models.Exceptions;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudTest.API.Middlewares
{
    public class ExceptionHandlerMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                

                await next.Invoke(context);
            }
            catch(ValidationException validationException)
            {
                context.Response.ContentType = "application/json";

                context.Response.StatusCode = 400;

                await context.Response.WriteAsJsonAsync(new {Errors = validationException.Errors,StatusCode = 400});
            }
            catch(Exception ex)
            {
                context.Response.ContentType = "application/json";

                context.Response.StatusCode = 500;

                await context.Response.WriteAsJsonAsync(new {Error=ex.Message, StatusCode = 500});
            }
        }
    }
}
