using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.Web;

namespace ChromeLogger
{
    [SuppressMessage("ReSharper", "UnusedType.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public static class Logger
    {
        static IChromeLogger CurrentContextLogger
        {
            get
            {
                IChromeLogger logger;
                var contextItems = HttpContext.Current.Items;
                if (!contextItems.Contains(CoreChromeLogger.HeaderName))
                {
                    logger = new CoreChromeLogger();
                    contextItems[CoreChromeLogger.HeaderName] = logger;
                }
                else
                {
                    logger = (IChromeLogger)contextItems[CoreChromeLogger.HeaderName];
                }

                return logger;
            }
        }

        public static void Log(object data) => CurrentContextLogger.Log(data);
        public static void Warn(object data) => CurrentContextLogger.Warn(data);
        public static void Error(object data) => CurrentContextLogger.Error(data);
        public static void Info(object data) => CurrentContextLogger.Info(data);
        public static void Group(object data) => CurrentContextLogger.Group(data);
        public static void GroupEnd(object data) => CurrentContextLogger.GroupEnd(data);
        public static void GroupCollapsed(object data) => CurrentContextLogger.GroupCollapsed(data);

        public static NameValueCollection GetHeader()
        {
            var header = CurrentContextLogger.GetHttpHeader();
            return new NameValueCollection { { header.Key, header.Value } };
        }
    }
}
