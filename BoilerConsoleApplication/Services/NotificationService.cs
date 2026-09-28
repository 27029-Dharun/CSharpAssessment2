namespace BoilerConsoleApplication.Services;

public class NotificationService
{
    public event Action<string>? Notify;

    public void DisplayNotification(string message)
    {
        Notify?.Invoke(message);
    }
}
