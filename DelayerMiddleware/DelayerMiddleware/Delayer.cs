using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelayerMiddleware
{
    public class DelayOptions { 
        public int MilliSecond { get; set; }
    }

    public class DelayerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly int _delayInMilliSecond=0;

        public DelayerMiddleware(RequestDelegate next, IOptions<DelayOptions> options)
        {
            this._next = next;
            _delayInMilliSecond = options.Value.MilliSecond;
        }
        public async Task InvokeAsync(HttpContext context)
        { 
            await Task.Delay(this._delayInMilliSecond);
            await _next(context);
        }

    }

    public static class DelayerMiddlewareExtension
    {
        public static IApplicationBuilder UseDelayer(this IApplicationBuilder app, int delayInMilliSecond)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            return app.UseDelayer(new DelayOptions { MilliSecond = delayInMilliSecond });
        }
        public static IApplicationBuilder UseDelayer(this IApplicationBuilder app, DelayOptions options) {

            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            return app.UseMiddleware<DelayerMiddleware>(Options.Create(options));
        }
    }
}
