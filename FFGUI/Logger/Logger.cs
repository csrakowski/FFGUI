using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class SimpleLogger
    {
        public static void LogMessage(string message, string category = "Messages")
        {
            Trace.WriteLine(message, category);
            Debug.WriteLine(message, category);
        }
    }
}
