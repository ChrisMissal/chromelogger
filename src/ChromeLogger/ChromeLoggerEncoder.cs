using System;
using System.Text;
using ServiceStack;
using ServiceStack.Text;

namespace ChromeLogger
{
    internal class ChromeLoggerEncoder
    {
        static ChromeLoggerEncoder()
        {
            JsConfig.EmitCamelCaseNames = true;
        }

        internal string Encode(LogData logData)
        {
            var serialized = logData.ToJson();
            var toEncodeAsBytes = Encoding.UTF8.GetBytes(serialized);
            return Convert.ToBase64String(toEncodeAsBytes);
        }
    }
}