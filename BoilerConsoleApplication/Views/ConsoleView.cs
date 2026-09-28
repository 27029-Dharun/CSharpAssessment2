using BoilerConsoleApplication.Models;

namespace BoilerConsoleApplication.Views;

public class ConsoleView
{
    private int currentNotificationLine = 0;

    /// <summary>
    /// Prints the message in the console.
    /// </summary>
    /// <param name="message"></param>
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
        string menuMessage = "----------------------------------\n" +
            "  Boiler Controller - Menu Option \n" +
            "----------------------------------\n" +
            "1. Start boiler operation\n" +
            "2. Stop boiler operation\n" +
            "3. Simulate error\n" +
            "4. Toggle interlock switch\n" +
            "5. Reset lockout\n" +
            "6. View event log\n" +
            "7. Exit\n";

        return this.GetEnumValue<MenuOption>(menuMessage);
    }

    public void PrintLog(List<LogEntry> logEntries)
    {
        Console.WriteLine("=====================================================================================");
        Console.WriteLine("|         Date        |     EventName   |                    Data                   |");
        Console.WriteLine("=====================================================================================");
        foreach (var entries in logEntries)
        {
            Console.WriteLine($"| {entries.TimeStamp} | {entries.Name, -15} | {entries.Data, -41} |");
        }
        Console.WriteLine("=====================================================================================");
    }

    /// <summary>
    /// Prints the notifications in the right side of the console window.
    /// </summary>
    /// <param name="message"></param>
    public void PrintNotification(string message)
    {
        (int currentLeft, int currentTop) = Console.GetCursorPosition();

        int startPosition = Console.WindowWidth - (Console.WindowWidth / 3);

        Console.SetCursorPosition(startPosition, currentNotificationLine++);
        Console.WriteLine(message);

        if(currentNotificationLine >= Console.WindowHeight)
        {
            ClearConsole();
            currentNotificationLine = 0;
        }

        Console.SetCursorPosition(currentLeft, currentTop);
    }

    /// <summary>
    /// Prints the countdown
    /// </summary>
    /// <param name="count"></param>
    /// <param name="status"></param>
    public void PrintCountDown(int count, BoilerStatus status)
    {
        (int currentLeft, int currentTop) = Console.GetCursorPosition();

        int left = 10;
        int top = Console.WindowHeight / 2;

        Console.SetCursorPosition(left, top);
        Console.Write(new string(' ', left * 2));

        Console.SetCursorPosition(left, top);
        Console.WriteLine($"Status: {status}");

        if(count == -1)
        {
            Console.Write(new string(' ', left*2));
            Console.SetCursorPosition(currentLeft, currentTop);
            return;
        }

        Console.Write(new string(' ', left));
        Console.WriteLine($"{count}   ");

        Console.SetCursorPosition (currentLeft, currentTop);
    }

    /// <summary>
    /// Reads a key and clears the console.
    /// </summary>
    public void PauseAndClear()
    {
        Console.WriteLine("Enter any key to cleat the console");
        Console.ReadKey();

        ClearConsole();
    }

    private void ClearLeftSide()
    {
        int endPosition = Console.WindowWidth - (Console.WindowWidth / 3);
        Console.SetCursorPosition(0, 0);

        for(int i = 0; i< Console.WindowHeight; i++)
        {
            Console.SetCursorPosition(0, i);
            Console.Write(new String(' ', endPosition));
        }

        Console.SetCursorPosition(0, 0);
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

    /// <summary>
    /// Displays the enum value and gets input from the user.
    /// </summary>
    /// <typeparam name="T">Type variable struct.</typeparam>
    /// <param name="message">String to be printed.</param>
    /// <returns>Returns a enum value entered by user.</returns>
    private T GetEnumValue<T>(string message)
       where T : struct, Enum
    {
        while (true)
        {
            string input = this.GetString(message);

            ClearLeftSide();

            if (Enum.TryParse(input, out T result) && Enum.IsDefined(result))
            {
                return result;
            }

            Console.WriteLine("Enter a valid option");
        }
    }

    /// <summary>
    /// Clears the console messages.
    /// </summary>
    private void ClearConsole()
    {
        Console.Write("\x1b[3J");
        Console.Clear();
    }
}