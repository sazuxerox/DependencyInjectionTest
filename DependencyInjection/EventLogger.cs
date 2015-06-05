using System.Diagnostics;

namespace DependencyInjection
{
    public class EventLogger : ILogger
    {
        public void Log(string message)
        {
            EventLog.WriteEntry("Mailservice", message);
        }
    }
}
