namespace BoilerConsoleApplication.Services;

/// <summary>
/// Contains the event to display notification.
/// </summary>
public class NotificationService
{
    /// <summary>
    /// An event triggered to print the notification.
    /// </summary>
    public event Action<string>? Notify;

    /// <summary>
    /// Invokes the method to display the notification.
    /// </summary>
    /// <param name="message"></param>
    public void DisplayNotification(string message)
    {
        Notify?.Invoke(message);
    }
}
