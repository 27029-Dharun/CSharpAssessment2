namespace BoilerConsoleApplication.CustomException;

internal class DataBaseException : Exception
{
    public DataBaseException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}