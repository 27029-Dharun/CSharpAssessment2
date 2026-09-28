using BoilerConsoleApplication.Controllers;
using BoilerConsoleApplication.Repository;
using BoilerConsoleApplication.Services;
using BoilerConsoleApplication.Views;

namespace BoilerConsoleApplication;

/// <summary>
/// Contains the application root and wires up the dependencies once.
/// </summary>
public class Program
{
    private static void Main()
    {
        ConsoleView view = new ConsoleView();
        LogEventService logEventService = new LogEventService();
        NotificationService notificationService = new NotificationService();
        CountDownService countDownService = new CountDownService();

        LogRepository logRepository = new LogRepository("Log.txt");
        LogService logService = new LogService(logRepository);

        BoilerService boilerService = new BoilerService(logEventService, notificationService, countDownService);
        BoilerController boilerController = new BoilerController(boilerService, logEventService, logService, notificationService, countDownService, view);

        boilerController.Run();
    }
}
