using Microsoft.AspNetCore.Builder;

namespace ChromeLogger
{
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Attaches the chrome logger header setting middleware to the pipeline.
        /// This method must be called at the start of the startup class Configure method.
        /// </summary>
        public static IApplicationBuilder UseChromeLogger(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ChromeLoggerMiddleware>();
        }
    }
}
