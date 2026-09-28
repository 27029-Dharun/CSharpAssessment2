namespace BoilerConsoleApplication.Models;

internal class LogEntry
{
    public LogEntry(DateTime date, EventName eventName, string data)
    {
        this.TimeStamp = date;
        this.Name = eventName;
        this.Data = data;
    }

    public EventName Name { get; set; }

    public DateTime TimeStamp { get; set; }

    public string Data { get; set; }
}
