using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minibank.Web.Middlevares
{
    public class ValidationExceptionMiddleware
    {
        public readonly RequestDelegate next;

        public ValidationExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (ValidationException exception)
            {
                await context.Response.WriteAsync($"Exception: {exception.Message}");
            }
        }
    }
}