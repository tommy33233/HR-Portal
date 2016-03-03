using HR_PortalInterfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class EventLogLogger:ILogger
    {
        EventLog log;
        public EventLogLogger()
        {

            if (!EventLog.SourceExists("ApplicationLog"))
            {
                EventLog.CreateEventSource("ApplicationLog", "SampleLog");
            }
        }

        private void DebugWriteLine(EventLogEntryType type, string message)
        {
            log = new EventLog();
            log.Source = "ApplicationLog";

            log.WriteEntry(message, type);

            log.Close();
        }

        public void Error(string message)
        {
            DebugWriteLine(EventLogEntryType.Error, "ERROR:  " + message);
        }

        public void Error(string format, params object[] args)
        {
            DebugWriteLine(EventLogEntryType.Error, "ERROR:  " + format);
        }

        public void Error(Exception ex, string message)
        {
            DebugWriteLine(EventLogEntryType.Error, "ERROR:  " + message + " Exception: " + ex);

        }

        public void Error(Exception ex, string format, params object[] args)
        {
            DebugWriteLine(EventLogEntryType.Error, "ERROR:  " + format + " Exception: " + ex);
        }

        public void Info(string message)
        {
            DebugWriteLine(EventLogEntryType.Information, "INFO:  " + message);
        }

        public void Info(string format, params object[] args)
        {
            DebugWriteLine(EventLogEntryType.Information, "INFO:  " + format);
        }

        public void Info(Exception ex, string message)
        {
            DebugWriteLine(EventLogEntryType.Information, "INFO:  " + message + " Exception: " + ex);
        }

        public void Info(Exception ex, string format, params object[] args)
        {
            DebugWriteLine(EventLogEntryType.Information, "INFO:  " + format + " Exception: " + ex);
        }
    }
}
