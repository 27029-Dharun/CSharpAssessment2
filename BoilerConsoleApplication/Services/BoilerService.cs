
using BoilerConsoleApplication.Models;

namespace BoilerConsoleApplication.Services;

/// <summary>
/// Contains the business logic for operating the boiler.
/// </summary>
public class BoilerService
{
    private LogEventService _eventService;
    private NotificationService _notificationService;
    private BoilerMachine _boilerMachine = new BoilerMachine();
    private CancellationTokenSource? cancellationTokenSource = null;

    /// <summary>
    /// Initialize the instance of <see cref="BoilerService"/>
    /// </summary>
    /// <param name="logEventService">Instance of the log event service</param>
    /// <param name="notificationService">Instance of the notification service.</param>
    public BoilerService(LogEventService logEventService, NotificationService notificationService)
    {
        _eventService = logEventService;
        _notificationService = notificationService;
    }

    /// <summary>
    /// Starts the boiler.
    /// </summary>
    internal void StartBoiler()
    {
        cancellationTokenSource = new CancellationTokenSource();

        if (_boilerMachine.Status != BoilerStatus.LockOut && _boilerMachine.Status != BoilerStatus.Ready)
        {
            _notificationService.DisplayNotification("Machine is running already");
            return;
        }

        if (_boilerMachine.Status == BoilerStatus.LockOut && _boilerMachine.InterLock == InterLock.Open)
        {
            _notificationService.DisplayNotification("Please lock the interlock & Reset lockout to start the boiler.");
            return;
        }

        if (_boilerMachine.Status == BoilerStatus.LockOut)
        {
            _notificationService.DisplayNotification("Please reset lockout to start the boiler.");
            return;
        }

        if (_boilerMachine.Status == BoilerStatus.Ready && _boilerMachine.InterLock == InterLock.Closed)
        {
            _ = StartBoilerAsync(cancellationTokenSource.Token);
        }
    }

    /// <summary>
    /// Starts the boiler async
    /// </summary>
    /// <param name="token">The cancellation token to cancel the operation.</param>
    /// <returns>A task that represents the boiler in running state.</returns>
    private async Task StartBoilerAsync(CancellationToken token)
    {
        try
        {
            _boilerMachine.SetStatus(BoilerStatus.PrePurge);
            this._notificationService.DisplayNotification("Boiler started, entered pre-purge stage");
            this._eventService.LogMessage(DateTime.Now, EventName.PrePurge, "Boiler entered pre-purge stage.");

            await Task.Delay(10000, token);

            _boilerMachine.SetStatus(BoilerStatus.Ignition);
            this._notificationService.DisplayNotification("Boiler entered ignition stage");
            this._eventService.LogMessage(DateTime.Now, EventName.Ignition, "Boiler entered ignition stage.");

            await Task.Delay(10000, token);

            _boilerMachine.SetStatus(BoilerStatus.Operational);
            this._notificationService.DisplayNotification("Boiler entered operational state");
            this._eventService.LogMessage(DateTime.Now, EventName.Operational, "Boiler entered operational state.");

            while (true)
            {
                await Task.Delay(10000, token);
            }
        }
        catch (OperationCanceledException)
        {
            _boilerMachine.SetStatus(BoilerStatus.Ready);
            this._notificationService.DisplayNotification("Boiler turned off");
            this._eventService.LogMessage(DateTime.Now, EventName.Ready, "Boiler turned off and set to ready.");
        }
    }

    /// <summary>
    /// Stops the boiler.
    /// </summary>
    public void StopBoiler()
    {
        if (cancellationTokenSource == null)
        {
            _notificationService.DisplayNotification($"The boiler is already in stopped");
            return;
        }

        cancellationTokenSource.Cancel();
    }

    /// <summary>
    /// Toggle the interlock switch.
    /// </summary>
    internal void ToggleInterlock()
    {
        if (_boilerMachine.InterLock == InterLock.Open)
        {
            _boilerMachine.SetInterLockStatus(InterLock.Closed);
            this._notificationService.DisplayNotification($"Toggled interlock to closed state");
            this._eventService.LogMessage(DateTime.Now,EventName.InterLockClosed,"Toggled interlock to closed state.");
        }
        else
        {
            _boilerMachine.SetInterLockStatus(InterLock.Open);
            this._notificationService.DisplayNotification("Toggled interlock to opened state");
            this._eventService.LogMessage(DateTime.Now,EventName.InterLockOpen,"Toggled interlock to open state.");
        }
    }

    /// <summary>
    /// Reset the boiler's lockout.
    /// </summary>
    internal void ResetLockOut()
    {
        if (_boilerMachine.InterLock == InterLock.Closed)
        {
            _boilerMachine.SetStatus(BoilerStatus.Ready);
            this._notificationService.DisplayNotification("Reset machine status to ready");
            this._eventService.LogMessage(DateTime.Now,EventName.Ready,"Reset machine status to ready.");
        }
    }
}
