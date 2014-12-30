namespace Kudu.Core.PCL.Deployment
{
    public interface IAutoSwapHandler
    {
        bool IsAutoSwapOngoing();

        void HandleAutoSwap(bool verifyActiveDeploymentIdChanged);
    }
}
