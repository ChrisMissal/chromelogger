using System.Collections.Generic;

namespace ChromeLogger
{
    public interface IChromeLogger
    {
        void Log(object data);
        void Warn(object data);
        void Error(object data);
        void Info(object data);
        void Group(object data);
        void GroupEnd(object data);
        void GroupCollapsed(object data);
        KeyValuePair<string, string> GetHttpHeader();
    }
}
