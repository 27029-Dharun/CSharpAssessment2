using BoilerConsoleApplication.Models;
using BoilerConsoleApplication.Services;
using BoilerConsoleApplication.Views;

namespace BoilerConsoleApplication.Controllers;

/// <summary>
/// Coordinates the flow between the view and the service.
/// </summary>
public class BoilerController
{
    private readonly BoilerService _boilerService;
    private readonly LogEventService _logEventService;
    private readonly NotificationService _notificationService;
    private readonly CountDownService _countdownEvent;
    private readonly LogService _logService;
    private readonly ConsoleView _view;

    /// <summary>
    /// Initialize the <see cref="BoilerController"/>
    /// </summary>
    /// <param name="boilerService">Instance of the boiler service</param>
    /// <param name="logEventService">Instance of the log events service.</param>
    /// <param name="logService">Instance of the log service</param>
    /// <param name="notificationService">Instance of the notification service</param>
    /// <param name="view">View of the boiler service.</param>
    public BoilerController(BoilerService boilerService, LogEventService logEventService, LogService logService, NotificationService notificationService, CountDownService countDownService, ConsoleView view)
    {
        _view = view;
        _boilerService = boilerService;
        _logService = logService;
        _logEventService = logEventService;
        _countdownEvent = countDownService;
        _countdownEvent.CountDown += this._view.PrintCountDown;
        _logEventService.LogEvent += _logService.LogEvent;
        _notificationService = notificationService;
        _notificationService.Notify += _view.PrintNotification;

        _notificationService.DisplayNotification("Boiler Controller Initialized");
        _logEventService.LogMessage(DateTime.Now, EventName.Initialize, "Boiler Controller Initialized.");
    }

    /// <summary>
    /// Loops the menu option and switch between the boiler operations
    /// </summary>
    public void Run()
    {
        while (true)
        {
            try
            {
                MenuOption option = this._view.GetMainMenuOption();

                switch (option)
                {
                    case MenuOption.StartBoiler:
                        this._boilerService.StartBoiler();
                        break;

                    case MenuOption.StopBoiler:
                        this._boilerService.StopBoiler();
                        break;

                    case MenuOption.SimulateError:
                        this._boilerService.SimulateError();
                        break;

                    case MenuOption.ToggleInterLock:
                        this._boilerService.ToggleInterlock();
                        break;

                    case MenuOption.ResetLockOut:
                        this._boilerService.ResetLockOut();
                        break;

                    case MenuOption.ViewLog:
                        this.DisplayLog();
                        break;

                    case MenuOption.Exit:
                        return;
                }
            }
            catch(Exception ex)
            {
                _view.PrintInfo(ex.Message);
            }
        }
    }

    /// <summary>
    /// Displays the log representing the events in the boiler.
    /// </summary>
    private void DisplayLog()
    {
        List<LogEntry> logEntries = this._logService.GetLog();
        this._view.PrintLog(logEntries);

        this._view.PauseAndClear();
    }
}