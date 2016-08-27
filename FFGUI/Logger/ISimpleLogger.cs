namespace Logger
{
    public interface ISimpleLogger
    {
        void LogMessage(string message, string category = "Messages");
    }
}