using BoilerConsoleApplication.Models;

namespace BoilerConsoleApplication.Repository
{
    internal class LogRepository
    {
        private readonly string _path;
        private object _lock = new object();
        internal LogRepository(string path)
        {
            _path = path;
            if(!File.Exists(path))
            {
                File.WriteAllText(path, "");
            }

        }

        public void WriteLog(LogEntry logEntry)
        {
            lock (_lock)
            {
                string message = $"{logEntry.TimeStamp},{logEntry.Name},{logEntry.Data}\n";
                File.AppendAllText(_path, message);
            }
        }

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
}
