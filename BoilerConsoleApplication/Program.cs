using BoilerConsoleApplication.Controllers;
using BoilerConsoleApplication.Repository;
using BoilerConsoleApplication.Services;
using BoilerConsoleApplication.Views;

namespace BoilerConsoleApplication
{
    internal class Program
    {
        static void Main()
        {
            ConsoleView view = new ConsoleView();
            LogEventService logEventService = new LogEventService();
            NotificationService notificationService = new NotificationService();

            LogRepository logRepository = new LogRepository("Log.txt");
            LogService logService = new LogService(logRepository);

            BoilerService boilerService = new BoilerService(logEventService, notificationService);
            BoilerController boilerController = new BoilerController(boilerService, logEventService, logService, notificationService, view);

            boilerController.Run();
        }
    }
}
