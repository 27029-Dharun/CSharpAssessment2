namespace BoilerConsoleApplication.Models
{
    internal class BoilerMachine
    {
        public BoilerMachine()
        {
            Status = BoilerStatus.LockOut;
            InterLock = InterLock.Open;
        }

        public BoilerStatus Status { get; set; }

        public InterLock InterLock { get; set; }
    }
}
