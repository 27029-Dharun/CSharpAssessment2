namespace BoilerConsoleApplication.Models;

/// <summary>
/// Contains all the events.
/// </summary>
public enum EventName
{
    /// <summary>
    /// Represents the event when the boiler is initialized.
    /// </summary>
    Initialize = 1,

    /// <summary>
    /// Represents the event when the boiler's interlock is in open state.
    /// </summary>
    InterLockClosed,

    /// <summary>
    /// Represents the event when the boiler's interlock is in closed state.
    /// </summary>
    InterLockOpen,

    /// <summary>
    /// Represents the event when the boiler is in ready state.
    /// </summary>
    Ready,

    /// <summary>
    /// Represents the event when the boiler is pre-purge state.
    /// </summary>
    PrePurge,

    /// <summary>
    /// Represents the event when the boiler is in ignition state.
    /// </summary>
    Ignition,

    /// <summary>
    /// Represents the event when the boiler is in operational state.
    /// </summary>
    Operational,

    /// <summary>
    /// Represents the events when the boiler enters the lockout state.
    /// </summary>
    LockOut,
}