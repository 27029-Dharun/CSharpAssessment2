namespace BoilerConsoleApplication.Models;

/// <summary>
/// Represents an log entry.
/// </summary>
public class LogEntry
{
    /// <summary>
    /// Initialize the <see cref="LogEntry"/>
    /// </summary>
    /// <param name="timeStamp">TimeStamp of the event</param>
    /// <param name="eventName">Name of the event</param>
    /// <param name="data">Data tell about the event</param>
    public LogEntry(DateTime timeStamp, EventName eventName, string data)
    {
        this.TimeStamp = timeStamp;
        this.Name = eventName;
        this.Data = data;
    }

    /// <summary>
    /// Gets or sets the name of event
    /// </summary
    /// <value>Name of the event.</value>
    public EventName Name { get; set; }

    /// <summary>
    /// Gets or sets the timestamp of event
    /// </summary
    /// <value>Time stamp of the event.</value>
    public DateTime TimeStamp { get; set; }

    /// <summary>
    /// Gets or sets the data of event
    /// </summary
    /// <value>Data of the event.</value>
    public string Data { get; set; }
}
