using System.Diagnostics;

namespace ChromeLogger
{
    public static class Logger
    {
        public static string HeaderName = "X-ChromeLogger-Data";

        private static readonly ChromeLoggerEncoder _chromeLoggerEncoder = new ChromeLoggerEncoder();

        public static string Log(object data)
        {
            return InnerLog(data);
        }

        public static string Warn(object data)
        {
            return InnerLog(data, "warn");
        }

        public static string Error(object data)
        {
            return InnerLog(data, "error");
        }

        public static string Info(object data)
        {
            return InnerLog(data, "info");
        }

        public static string Group(object data)
        {
            return InnerLog(data, "group");
        }

        public static string GroupEnd(object data)
        {
            return InnerLog(data, "groupEnd");
        }

        public static string GroupCollapsed(object data)
        {
            return InnerLog(data, "groupCollapsed");
        }

        private static string InnerLog(object data, string level = "")
        {
            var callData = new StackData(new StackTrace(1, true));
            var logData = new LogData(callData, level, data);
            var result = _chromeLoggerEncoder.Encode(logData);

            return result;
        }
    }
}
