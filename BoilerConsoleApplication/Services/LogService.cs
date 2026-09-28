using BoilerConsoleApplication.Models;
using BoilerConsoleApplication.Repository;

namespace BoilerConsoleApplication.Services;

public class LogService
{
    private readonly LogRepository _logRepository;

    internal LogService(LogRepository logRepository)
    {
        _logRepository = logRepository;
    }

    internal void LogEvent(DateTime timeStamp, EventName name, string data)
    {
        LogEntry logEntry = new LogEntry(timeStamp, name, data);
        _logRepository.WriteLog(logEntry);
    }
}
