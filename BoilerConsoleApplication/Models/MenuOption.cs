namespace BoilerConsoleApplication.Models;

/// <summary>
/// Contains all the menu operations that are all available.
/// </summary>
public enum MenuOption
{
    /// <summary>
    /// Represents an option to start the boiler.
    /// </summary>
    StartBoiler = 1,

    /// <summary>
    /// Represents an option to stop the boiler.
    /// </summary>
    StopBoiler = 2,

    /// <summary>
    /// Represents an option to simulate an error to the boiler operation.
    /// </summary>
    SimulateError = 3,

    /// <summary>
    /// Represents an option to toggle the interlock
    /// </summary>
    ToggleInterLock = 4,

    /// <summary>
    /// Represents an option to reset the boiler.
    /// </summary>
    ResetLockOut = 5,

    /// <summary>
    /// Represents an option to view all the logs.
    /// </summary>
    ViewLog = 6,

    /// <summary>
    /// Represents an option to exit the application.
    /// </summary>
    Exit = 7,
}
