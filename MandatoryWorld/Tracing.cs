using System.Diagnostics;
using System.IO;

namespace MandatoryWorld
{
    public class Tracing
    {
        /// <summary>
        /// This is my Tracing class that writes everything that is written in the console to a txt document.
        /// </summary>
        /// <param name="stuff">the string that is to be written in the txt document</param>
        public static void TraceWorker(string stuff)
        {
            using (FileStream myFileStream = new FileStream("GameFile.txt", FileMode.Append))
            {
                // Create a new text writer using the output stream
                // and add it to the trace listeners.
                TextWriterTraceListener listener = new TextWriterTraceListener(myFileStream);
                Trace.Listeners.Add(listener);

                // Write output to the file.
                Trace.WriteLine(stuff);

                // Flush and close the output stream.
                Trace.Flush();
                Trace.Close();
            }
        }
    }
}
