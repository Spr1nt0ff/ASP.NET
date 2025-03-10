using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace FirstApp
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class NextComponent
    {
        private readonly RequestDelegate _next;

        public NextComponent(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            int myid = 0;
            string? id = httpContext.Request.Query["id"];

            if (id != null)
            {
                myid = int.Parse(id);
            }
            if (myid > 10)
            {
                return httpContext.Response.WriteAsync("id > 10");
            }
            else
            {
                return _next(httpContext);
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class NextComponentExtensions
    {
        public static IApplicationBuilder UseNextComponent(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<NextComponent>();
        }
    }
}
