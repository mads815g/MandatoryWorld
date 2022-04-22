using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryWorld
{
    public static class Logger
    {
        public static void LogInformation(string info)
        {
            Console.WriteLine(info);
            Tracing.TraceWorker(info, TraceEventType.Information);
        }

        public static void LogCritical(string info)
        {
            Console.WriteLine(info);
            Tracing.TraceWorker(info, TraceEventType.Critical);
        }

        public static void LogError(string info)
        {
            Console.WriteLine(info);
            Tracing.TraceWorker(info, TraceEventType.Error);
        }
    }
}
