using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GatewayService.Infrastructure
{
    public class AsyncRouteMiddlewire
    {
        private readonly RequestDelegate _next;
        public AsyncRouteMiddlewire(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            await _next(httpContext);
        }
    }
    public static class AsyncRouteMiddlewireExtensions
    {
        public static IApplicationBuilder UseAsyncRouteMiddlewire(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AsyncRouteMiddlewire>();
        }
    }
}
