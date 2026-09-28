using BoilerConsoleApplication.Models;

namespace BoilerConsoleApplication.Services;

public class LogEventService
{
    public event Action<DateTime,EventName,string>? LogEvent;

    public void LogMessage(DateTime timeStamp, EventName name, string data)
    {
        LogEvent?.Invoke(timeStamp, name, data);
    }
}
