namespace BoilerConsoleApplication.Models
{
    internal enum BoilerStatus
    {
        LockOut = 1,

        Ready,

        PrePurge,

        Ignition,

        Operational,
    }
}
