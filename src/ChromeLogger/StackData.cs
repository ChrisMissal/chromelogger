using System.Diagnostics;
using System.Linq;

namespace ChromeLogger
{
    readonly struct StackData
    {
        public string FileName { get; }
        public int LineNumber { get; }

        public StackData(StackTrace stackTrace)
        {
            var frames = stackTrace.GetFrames();
            
            if (frames == null || frames.Length == 0)
            {
                this.LineNumber = 0;
                this.FileName = "<unknown>";
                return;
            }

            var callSite = frames.First();
            this.FileName = callSite.GetFileName();
            this.LineNumber = callSite.GetFileLineNumber();
        }
    }
}
