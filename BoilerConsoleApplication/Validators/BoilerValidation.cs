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
    /// <returns></returns>
    public static bool IsMachineRunning(BoilerMachine machine)
    {
        if (machine.Status == BoilerStatus.Ready || machine.Status == BoilerStatus.LockOut)
        {
            return false;
        }

        return true;
    }

    
    public static bool CanSimulateError(BoilerMachine boilerMachine)
    {
        return boilerMachine.Status == BoilerStatus.Operational;
    }
}