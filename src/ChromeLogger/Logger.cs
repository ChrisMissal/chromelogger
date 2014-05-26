using System.Diagnostics;
using System.Web;
using System.Collections.Specialized;
using System.Collections;
using System.Collections.Generic;

namespace ChromeLogger
{
    public static class Logger
    {
        internal const string HeaderName = "X-ChromeLogger-Data";

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

        public static NameValueCollection GetHeader()
        {
            var logData = new LogData(Rows);
            var data = _chromeLoggerEncoder.Encode(logData);

            return new NameValueCollection { { HeaderName, data } };
        }

        private static IDictionary Items
        {
            get { return HttpContext.Current.Items; }
        }

        private static List<object> Rows
        {
            get
            {
                if (!Items.Contains(HeaderName))
                    Items.Add(HeaderName, new List<object>());

                return (List<object>) Items[HeaderName];
            }
        }

        private static object GetRow(object data, string level)
        {
            var stackData = new StackData(new StackTrace(3, true));
            var type = data.GetType();
            return new object[]
            {
                new object[] {new {___class_name = type.Namespace + "." + type.Name, data}},
                string.Format("{0} : {1}", stackData.FileName, stackData.LineNumber),
                level,
            };
        }

        private static void InnerLog(object data, string level = "")
        {
            var row = GetRow(data, level);
            Rows.Add(row);
        }
    }
}
