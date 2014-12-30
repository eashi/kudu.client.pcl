namespace Kudu.Core.PCL.Deployment
{
    public interface IDeploymentManagerFactory
    {
        IDeploymentManager CreateDeploymentManager();
    }
}
