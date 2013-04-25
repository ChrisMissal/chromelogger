using System.Diagnostics;
using System.Web;

namespace ChromeLogger
{
    public static class Logger
    {
        internal static string HeaderName = "X-ChromeLogger-Data";

        private static readonly ChromeLoggerEncoder _chromeLoggerEncoder = new ChromeLoggerEncoder();

        public static void Log(object data)
        {
            InnerLog(data);
        }

        public static void Warn(object data)
        {
            InnerLog(data, "warn");
        }

        public static void Error(object data)
        {
            InnerLog(data, "error");
        }

        public static void Info(object data)
        {
            InnerLog(data, "info");
        }

        public static void Group(object data)
        {
            InnerLog(data, "group");
        }

        public static void GroupEnd(object data)
        {
            InnerLog(data, "groupEnd");
        }

        public static void GroupCollapsed(object data)
        {
            InnerLog(data, "groupCollapsed");
        }

        private static void InnerLog(object data, string level = "")
        {
            var callData = new StackData(new StackTrace(1, true));
            var logData = new LogData(callData, level, data);
            var result = _chromeLoggerEncoder.Encode(logData);

            HttpContext.Current.Response.AppendHeader(HeaderName, result);
        }
    }
}
