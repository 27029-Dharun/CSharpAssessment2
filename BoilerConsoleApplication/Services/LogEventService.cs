namespace BoilerConsoleApplication.Services;

internal class LogEventService
{
    public event Action<string>? LogEvent;

    public void LogMessage(string log)
    {
        LogEvent?.Invoke(log);
    }
}
