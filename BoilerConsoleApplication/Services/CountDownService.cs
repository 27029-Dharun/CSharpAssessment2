using BoilerConsoleApplication.Models;

namespace BoilerConsoleApplication.Services;

/// <summary>
/// Contains the logic to print the count down for boiler machine stages.
/// </summary>
public class CountDownService
{
    /// <summary>
    /// Event to trigger the CountDown display method.
    /// </summary>
    public event Action<int, BoilerStatus>? CountDown;

    /// <summary>
    /// Iterates and displays the timer each second.
    /// </summary>
    /// <param name="timer">The timing duration for the machine.</param>
    /// <param name="status">The status of the machine.</param>
    /// <param name="token">Cancellation token</param>
    /// <returns>A task representing the display timer method.</returns>
    public async Task DisplayTimer(int timer, BoilerStatus status, CancellationToken token)
    {
        for (int i = timer; i >= 0; i--)
        {
            DisplayCountDown(i, status);

            await Task.Delay(1000, token);
        }

        DisplayCountDown(-1, BoilerStatus.Operational);
    }

    private void DisplayCountDown(int timer, BoilerStatus status)
    {
        CountDown?.Invoke(timer, status);
    }
}
