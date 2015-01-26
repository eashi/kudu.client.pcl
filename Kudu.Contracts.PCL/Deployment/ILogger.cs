namespace Kudu.Contracts.PCL.Deployment
{
    public interface ILogger
    {
        ILogger Log(string value, LogEntryType type);
    }
}
