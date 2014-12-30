namespace Kudu.Core.PCL.Deployment
{
    public interface ILogger
    {
        ILogger Log(string value, LogEntryType type);
    }
}
