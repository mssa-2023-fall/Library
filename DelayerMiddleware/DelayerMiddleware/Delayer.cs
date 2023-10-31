using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger logger;
        private readonly int _delayInMilliSecond=0;

        public DelayerMiddleware(RequestDelegate next, IOptions<DelayOptions> options, ILogger<DelayerMiddleware> logger)
        {
            logger.LogInformation("DelayerMiddleware constructor called.");
            this._next = next;
            this.logger = logger;
            _delayInMilliSecond = options.Value.MilliSecond;
            logger.LogInformation("DelayerMiddleware constructor finished.");

        }
        public async Task InvokeAsync(HttpContext context)
        {
            logger.LogInformation("DelayerMiddleware Invoke starting.");
            await Task.Delay(this._delayInMilliSecond);
            logger.LogInformation("DelayerMiddleware Invoke Completed.");
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
