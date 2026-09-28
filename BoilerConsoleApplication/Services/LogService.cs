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

    internal void LogEvent(LogEntry logEntry)
    {
        _logRepository.WriteLog(logEntry);
    }
}
