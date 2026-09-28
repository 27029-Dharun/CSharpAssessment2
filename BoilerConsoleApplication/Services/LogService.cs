using BoilerConsoleApplication.Models;
using BoilerConsoleApplication.Repository;

namespace BoilerConsoleApplication.Services;

/// <summary>
/// Contains the logic to write the events in a file.
/// </summary>
public class LogService
{
    private readonly LogRepository _logRepository;

    /// <summary>
    /// Initialize the <see cref="LogService"/>
    /// </summary>
    /// <param name="logRepository">The repository instance.</param>
    public LogService(LogRepository logRepository)
    {
        _logRepository = logRepository;
    }

    /// <summary>
    /// Append the log to the file.
    /// </summary>
    /// <param name="timeStamp">Timestamp of the event.</param>
    /// <param name="name">Name of the event.</param>
    /// <param name="data">Data of the event.</param>
    public void LogEvent(DateTime timeStamp, EventName name, string data)
    {
        LogEntry logEntry = new LogEntry(timeStamp, name, data);
        _logRepository.WriteLog(logEntry);
    }

    /// <summary>
    /// Gets the log from the file.
    /// </summary>
    /// <returns></returns>
    public List<LogEntry> GetLog()
    {
        return this._logRepository.ReadLog();
    }
}
