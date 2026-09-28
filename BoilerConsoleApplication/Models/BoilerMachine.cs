namespace BoilerConsoleApplication.Models;

/// <summary>
/// Represents the boiler machine
/// </summary>
public class BoilerMachine
{
    /// <summary>
    /// Initialize the boiler machine.
    /// </summary>
    public BoilerMachine()
    {
        Status = BoilerStatus.LockOut;
        InterLock = InterLock.Open;
    }

    /// <summary>
    /// Gets the Status of the boiler.
    /// </summary>
    /// <value>Status of the boiler.</value>
    public BoilerStatus Status { get; private set; }

    /// <summary>
    /// Gets the interlock status of the boiler.
    /// </summary>
    /// <value>Interlock status of the boiler.</value>
    public InterLock InterLock { get; private set; }

    /// <summary>
    /// Sets the status of the boiler.
    /// </summary>
    /// <param name="status">Status of the boiler</param>
    public void SetStatus(BoilerStatus status)
    {
        Status = status;
    }

    /// <summary>
    /// Sets the interlock status of the boiler.
    /// </summary>
    /// <param name="interLock">Interlock status of the boiler</param>
    public void SetInterLockStatus(InterLock interLock)
    {
        InterLock = interLock;
    }
}
