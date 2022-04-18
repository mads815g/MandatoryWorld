using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryWorld
{
    public class Tracing
    {
        public static void TraceWorker(string stuff)
        {
            ConsoleTraceListener consoleTraceListener = new ConsoleTraceListener();
            Trace.Listeners.Add(consoleTraceListener);
            Trace.AutoFlush = true;
            Trace.WriteLine(stuff);
            Trace.Flush();
        }
    }
}
