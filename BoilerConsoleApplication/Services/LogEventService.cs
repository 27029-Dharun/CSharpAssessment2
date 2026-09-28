namespace BoilerConsoleApplication.Services;

public class LogEventService
{
    public event Action<string>? LogEvent;

    public void LogMessage(string log)
    {
        LogEvent?.Invoke(log);
    }
}
