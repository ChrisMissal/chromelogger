namespace ChromeLogger
{
    internal class LogData
    {
        public LogData(StackData stackData, string level, object obj)
        {
            var type = obj.GetType();

            Version = "0.2";
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

        public string Version { get; private set; }

        public string[] Columns { get; private set; }

        public object[] Rows { get; private set; }
    }
}