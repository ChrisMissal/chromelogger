using System.Diagnostics;
using System.Reflection;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace ChromeLogger
{
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    readonly struct LogData
    {
        static readonly string s_Version = FileVersionInfo
            .GetVersionInfo(Assembly.GetExecutingAssembly().Location)
            .FileVersion;

        public string Version { get; }
        public string[] Columns { get; }
        public object[] Rows { get; }

        public LogData(IEnumerable<object> rows)
        {
            this.Version = s_Version;
            this.Columns = new[] { "log", "backtrace", "type" };
            this.Rows = rows.ToArray();
        }
    }
}
