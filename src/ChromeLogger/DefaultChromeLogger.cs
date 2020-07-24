using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace ChromeLogger
{
    [SuppressMessage("ReSharper", "UnusedType.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class CoreChromeLogger : IChromeLogger
    {
        public const string HeaderName = "X-ChromeLogger-Data";

        static readonly JsonSerializerOptions s_JsonSerializerOptions = new JsonSerializerOptions
        {
            DictionaryKeyPolicy = JsonNamingPolicy.CamelCase, 
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        readonly List<object> _rows;

        public CoreChromeLogger()
        {
            this._rows = new List<object>();
        }

        public void Log(object data)
        {
            this.Log(data, "");
        }

        public void Warn(object data)
        {
            this.Log(data, "warn");
        }

        public void Error(object data)
        {
            this.Log(data, "error");
        }

        public void Info(object data)
        {
            this.Log(data, "info");
        }

        public void Group(object data)
        {
            this.Log(data, "group");
        }

        public void GroupEnd(object data)
        {
            this.Log(data, "groupEnd");
        }

        public void GroupCollapsed(object data)
        {
            this.Log(data, "groupCollapsed");
        }

        void Log(object data, string level)
        {
            var row = BuildRow(data, level);
            this._rows.Add(row);
        }

        static object BuildRow(object data, string level)
        {
            var stackData = new StackData(new StackTrace(4, true));
            var type = data.GetType();
            return new object[]
            {
                new object[] { new { ___class_name = type.Namespace + "." + type.Name, data } },
                $"{stackData.FileName} : {stackData.LineNumber}",
                level
            };
        }

        public KeyValuePair<string, string> GetHttpHeader()
        {
            var logData = new LogData(this._rows);
            var data = Encode(logData);
            return new KeyValuePair<string, string>(HeaderName, data);
        }

        static string Encode(LogData logData)
        {
            var toEncodeAsBytes = JsonSerializer.SerializeToUtf8Bytes(logData, s_JsonSerializerOptions);
            return Convert.ToBase64String(toEncodeAsBytes);
        }
    }
}
