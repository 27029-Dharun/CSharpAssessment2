namespace BoilerConsoleApplication.Services;

internal class NotificationService
{
    public event Action<string>? Notify;

    public void DisplayNotification(string message)
    {
        Notify?.Invoke(message);
    }
}
