using System.Diagnostics;
using System.Reflection;

namespace ChromeLogger
{
    internal class LogData
    {
        private static string _version;

        public LogData(StackData stackData, string level, object obj)
        {
            var type = obj.GetType();

            Version = GetVersion();
            Columns = new[] { "log", "backtrace", "type" };

            Rows = new object[]
            {
                new object[]
                {
                    new object[] { new { ___class_name = type.Namespace + "." + type.Name, obj } },
                    string.Format("{0} : {1}", stackData.FileName, stackData.LineNumber),
                    level,
                }
            };
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