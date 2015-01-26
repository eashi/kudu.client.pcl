namespace Kudu.Client.PCL.Infrastructure
{
    public interface IEventProvider
    {
        void Start();
        void Stop();
        bool IsActive { get; }
    }
}
