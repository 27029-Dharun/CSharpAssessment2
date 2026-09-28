using BoilerConsoleApplication.Models;

namespace BoilerConsoleApplication.Validators;

/// <summary>
/// Contains the business validation logics.
/// </summary>
public static class BoilerValidation
{
    /// <summary>
    /// Checks if the machine is in running state.
    /// </summary>
    /// <param name="machine"></param>
    /// <returns>Boolean true if machine is running; otherwise, false.</returns>
    public static bool IsMachineRunning(BoilerMachine machine)
    {
        if (machine.Status == BoilerStatus.Ready || machine.Status == BoilerStatus.LockOut)
        {
            return false;
        }

        return true;
    }

    /// <summary>
    /// Checks if the boiler is in operational state.
    /// </summary>
    /// <param name="boilerMachine"></param>
    /// <returns>Boolean true if machine is operational; otherwise, false.</returns>
    public static bool CanSimulateError(BoilerMachine boilerMachine)
    {
        return boilerMachine.Status == BoilerStatus.Operational;
    }
}