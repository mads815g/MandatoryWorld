using System.Diagnostics;
using System.IO;

namespace MandatoryWorld
{
   class Tracing
    {
        /// <summary>
        /// This is my Tracing class that writes everything that is written in the console to a txt document.
        /// </summary>
        /// <param name="stuff">the string that is to be written in the txt document</param>

        private static TraceSource ts = new TraceSource("Mandatory Game");

        public static void TraceWorker(string stuff, TraceEventType type)
        {
            ts.Switch = new SourceSwitch("switch", "All");
            ts.Listeners.Remove("Default");
            TextWriterTraceListener listener = new TextWriterTraceListener("GameFile.txt");
            listener.Filter = new EventTypeFilter(SourceLevels.Information);
            ts.Listeners.Add(listener);
            ts.TraceEvent(type, 1, stuff);
            ts.Close();
            
        }
    }
}
