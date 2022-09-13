using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minibank.Web.Middlevares
{
    public class UserFriendlyExceptionMiddleware
    {
        public readonly RequestDelegate next;

        public UserFriendlyExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (UserFriendlyException exception)
            {
                await context.Response.WriteAsync($"Exception: {exception.Message}");
            }
        }
    }
}