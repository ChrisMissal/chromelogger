using System.Diagnostics;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace ChromeLogger
{
    internal class LogData
    {
        private static string _version;

        public LogData(IEnumerable<object> rows)
        {
            Version = GetVersion();
            Columns = new[] { "log", "backtrace", "type" };

            Rows = rows.ToArray();
        }

        private string GetVersion()
        {
            return _version ?? (_version = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion);
        }

        public string Version { get; private set; }

        public string[] Columns { get; private set; }

        public object[] Rows { get; private set; }
    }
}