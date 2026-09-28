namespace BoilerConsoleApplication.Models;

public class BoilerMachine
{
    public BoilerMachine()
    {
        Status = BoilerStatus.LockOut;
        InterLock = InterLock.Open;
    }

    public BoilerStatus Status { get; set; }

    public InterLock InterLock { get; set; }
}
