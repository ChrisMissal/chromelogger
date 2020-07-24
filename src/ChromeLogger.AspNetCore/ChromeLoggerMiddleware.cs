using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ChromeLogger
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class ChromeLoggerMiddleware
    {
        readonly RequestDelegate _next;
        readonly IChromeLogger _chromeLogger;

        public ChromeLoggerMiddleware(RequestDelegate next, IChromeLogger chromeLogger)
        {
            this._next = next;
            this._chromeLogger = chromeLogger;
        }

        public Task Invoke(HttpContext context)
        {
            context.Response.OnStarting(
                h =>
                {
                    var headers = (IHeaderDictionary)h;
                    var header = this._chromeLogger.GetHttpHeader();
                    headers[header.Key] = header.Value;
                    return Task.CompletedTask;
                },
                context.Response.Headers);

            return this._next(context);
        }
    }
}
