using System;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ChromeLogger
{
    internal class ChromeLoggerEncoder
    {
        private static readonly JsonSerializerSettings _serializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
        };

        internal string Encode(LogData logData)
        {
            var serialized = JsonConvert.SerializeObject(logData, _serializerSettings);
            var toEncodeAsBytes = Encoding.UTF8.GetBytes(serialized);
            return Convert.ToBase64String(toEncodeAsBytes);
        }
    }
}