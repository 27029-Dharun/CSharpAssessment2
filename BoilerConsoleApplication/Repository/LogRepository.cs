using BoilerConsoleApplication.Models;

namespace BoilerConsoleApplication.Repository;

/// <summary>
/// Contains the log details of each event.
/// </summary>
public class LogRepository
{
    private readonly string _path;
    private object _lock = new object();

    /// <summary>
    /// Initialize the instance of <see cref="LogRepository"/>
    /// </summary>
    /// <param name="path"></param>
    internal LogRepository(string path)
    {
        _path = path;
        if(!File.Exists(path))
        {
            File.WriteAllText(path, "");
        }

    }

    /// <summary>
    /// Writes the log in the log file.
    /// </summary>
    /// <param name="logEntry">The log entry to be logged.</param>
    public void WriteLog(LogEntry logEntry)
    {
        lock (_lock)
        {
            string message = $"{logEntry.TimeStamp},{logEntry.Name},{logEntry.Data}\n";
            File.AppendAllText(_path, message);
        }
    }

    /// <summary>
    /// Reads the log from the file.
    /// </summary>
    /// <returns></returns>
    public List<LogEntry> ReadLog()
    {
        List<LogEntry> logInFile = new List<LogEntry>();
        string logs = File.ReadAllText(_path);
        string[] logsList = logs.Split("\n");

        foreach (var log in logsList)
        {
            string[] logEntries = log.Split(",");
            DateTime date = DateTime.Parse(logEntries[0]);
            _ = Enum.TryParse(logEntries[1], out EventName eventName);
            LogEntry entry = new LogEntry(date, eventName, logEntries[2]);
            logInFile.Add(entry);
        }

        return logInFile;
    }
}
