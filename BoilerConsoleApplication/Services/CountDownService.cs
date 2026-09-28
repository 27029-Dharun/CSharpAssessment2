using BoilerConsoleApplication.Models;

namespace BoilerConsoleApplication.Services;

public class CountDownService
{
    public event Action<int, BoilerStatus>? CountDown;

    public async Task DisplayTimer(int timer, BoilerStatus status, CancellationToken token)
    {
        for (int i = 10; i >= 0; i--)
        {
            DisplayCountDown(i, status);

            await Task.Delay(1000, token);
        }
    }

    private void DisplayCountDown(int timer, BoilerStatus status)
    {
        CountDown?.Invoke(timer, status);
    }
}
