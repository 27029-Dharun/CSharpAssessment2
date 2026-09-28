namespace BoilerConsoleApplication.Models;

/// <summary>
/// Contains all the events.
/// </summary>
public enum EventName
{
    /// <summary>
    /// Represents the event when the machine is initialized.
    /// </summary>
    Initialize = 1,

    /// <summary>
    /// Represents the event when the machine's interlock is in open state.
    /// </summary>
    InterLockClosed = 2,

    /// <summary>
    /// Represents the event when the machine's interlock is in closed state.
    /// </summary>
    InterLockOpen,

    /// <summary>
    /// Represents the event when the machine is in ready state.
    /// </summary>
    Ready,

    /// <summary>
    /// Represents the event when the machine is pre-purge state.
    /// </summary>
    PrePurge,

    /// <summary>
    /// Represents the event when the machine is in ignition state.
    /// </summary>
    Ignition,

    /// <summary>
    /// Represents the event when the machine is in operational state.
    /// </summary>
    Operational,
}