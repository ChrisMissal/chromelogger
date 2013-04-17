using System.Diagnostics;
using System.Linq;

namespace ChromeLogger
{
    internal class StackData
    {
        public StackData(StackTrace stackTrace)
        {
            var frames = stackTrace.GetFrames();
            var callSite = frames.First();

            FileName = callSite.GetFileName();
            LineNumber = callSite.GetFileLineNumber();
        }

        public string FileName { get; private set; }

        public int LineNumber { get; private set; }
    }
}