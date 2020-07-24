using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace ChromeLogger
{
    public class ChromeLogger : IChromeLogger
    {
        readonly IHttpContextAccessor _contextAccessor;

        IChromeLogger CurrentContextLogger
        {
            get
            {
                if (this._contextAccessor.HttpContext.Items.TryGetValue(
                        CoreChromeLogger.HeaderName,
                        out var loggerObj)
                    && loggerObj is IChromeLogger logger)
                {
                    return logger;
                }

                logger = new CoreChromeLogger();
                this._contextAccessor.HttpContext.Items[CoreChromeLogger.HeaderName] = logger;
                return logger;
            }
        }

        public ChromeLogger(IHttpContextAccessor contextAccessor)
        {
            this._contextAccessor = contextAccessor;
        }

        public void Log(object data) => this.CurrentContextLogger.Log(data);
        public void Warn(object data) => this.CurrentContextLogger.Warn(data);
        public void Error(object data) => this.CurrentContextLogger.Error(data);
        public void Info(object data) => this.CurrentContextLogger.Info(data);
        public void Group(object data) => this.CurrentContextLogger.Group(data);
        public void GroupEnd(object data) => this.CurrentContextLogger.GroupEnd(data);
        public void GroupCollapsed(object data) => this.CurrentContextLogger.GroupCollapsed(data);
        public KeyValuePair<string, string> GetHttpHeader() => this.CurrentContextLogger.GetHttpHeader();
    }
}
