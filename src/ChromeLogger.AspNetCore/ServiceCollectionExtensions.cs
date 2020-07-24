using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;

namespace ChromeLogger
{
    [SuppressMessage("ReSharper", "UnusedType.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddChromeLogger(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddSingleton<IChromeLogger, ChromeLogger>();
            return services;
        }
    }
}
