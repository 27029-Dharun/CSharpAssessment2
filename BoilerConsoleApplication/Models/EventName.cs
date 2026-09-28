namespace BoilerConsoleApplication.Models
{
    public enum EventName
    {
        Initialize = 1,

        InterLockClosed = 2,

        InterLockOpen,

        Ready,

        PrePurge,

        Ignition,

        Operational,
    }
}