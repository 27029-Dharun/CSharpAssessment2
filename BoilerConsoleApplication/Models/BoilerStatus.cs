namespace BoilerConsoleApplication.Models;

/// <summary>
/// Contains the boiler status
/// </summary>
public enum BoilerStatus
{
    /// <summary>
    /// Represents the lock out state.
    /// </summary>
    LockOut = 1,

    /// <summary>
    /// Represents the ready state.
    /// </summary>
    Ready,

    /// <summary>
    /// Represents the pre-purge state.
    /// </summary>
    PrePurge,

    /// <summary>
    /// Represents the ignition state.
    /// </summary>
    Ignition,

    /// <summary>
    /// Represents the operational state.
    /// </summary>
    Operational,
}
