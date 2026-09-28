using BoilerConsoleApplication.Models;

namespace BoilerConsoleApplication.Services;

/// <summary>
/// Contains the log event to log the error in the file.
/// </summary>
public class LogEventService
{
    /// <summary>
    /// An event to trigger logging function.
    /// </summary>
    public event Action<DateTime,EventName,string>? LogEvent;

    /// <summary>
    /// Invokes the events and logs the message.
    /// </summary>
    /// <param name="timeStamp"></param>
    /// <param name="name"></param>
    /// <param name="data"></param>
    public void LogMessage(DateTime timeStamp, EventName name, string data)
    {
        LogEvent?.Invoke(timeStamp, name, data);
    }
}
