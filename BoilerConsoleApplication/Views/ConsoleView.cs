using BoilerConsoleApplication.Models;

namespace BoilerConsoleApplication.Views;

public class ConsoleView
{
    /// <summary>
    /// Prints the string.
    /// </summary>
    /// <param name="message">The string to be printed.</param>
    public void PrintInfo(string message)
    {
        Console.WriteLine(message);
    }

    /// <summary>
    /// Gets the main menu option from the user.
    /// </summary>
    /// <returns>The menu option entered by the user.</returns>
    public MenuOption GetMainMenuOption()
    {
        string menuMessage = "  Boiler Controller\n" +
            "1. Start boiler operation\n" +
            "2. Stop boiler operation\n" +
            "3. Simulate error\n" +
            "4. Toggle interlock switch\n" +
            "5. Reset lockout\n" +
            "6. View event log\n" +
            "7. Exit\n";

        return this.GetEnumValue<MenuOption>(menuMessage);
    }

    /// <summary>
    /// Displays the enum value and gets input from the user.
    /// </summary>
    /// <typeparam name="T">Type variable struct.</typeparam>
    /// <param name="message">String to be printed.</param>
    /// <returns>Returns a enum value entered by user.</returns>
    public T GetEnumValue<T>(string message)
       where T : struct, Enum
    {
        while (true)
        {
            string input = this.GetString(message);
            if (Enum.TryParse(input, out T result) && Enum.IsDefined(result))
            {
                return result;
            }

            Console.Clear();
            Console.WriteLine("Enter a valid option");
        }
    }

    /// <summary>
    /// Clears the console messages.
    /// </summary>
    public void ClearConsole()
    {
        Console.Write("\x1b[3J");
        Console.Clear();
    }

    /// <summary>
    /// Gets the string input from the user.
    /// </summary>
    /// <param name="message">Message to be printed.</param>
    /// <returns>int value that we got as input.</returns>
    private string GetString(string message)
    {
        Console.Write(message);
        string input = (Console.ReadLine() ?? string.Empty).Trim();

        return input;
    }

    internal void PrintLog(List<LogEntry> logEntries)
    {
        Console.WriteLine("          Date        |        EventName    |                       Data           ");
        foreach (var entries in logEntries)
        {
            Console.WriteLine($"{entries.TimeStamp}, {entries.Name}, {entries.Data}");
        }
    }
}