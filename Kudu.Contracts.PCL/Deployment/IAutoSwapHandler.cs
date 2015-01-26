namespace Kudu.Contracts.PCL.Deployment
{
    public interface IAutoSwapHandler
    {
        bool IsAutoSwapOngoing();

        void HandleAutoSwap(bool verifyActiveDeploymentIdChanged);
    }
}
