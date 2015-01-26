using System;

namespace Kudu.Contracts.PCL.Deployment
{
    public class DeploymentFailedException : InvalidOperationException
    {
        public DeploymentFailedException(Exception innerException)
            : base("Deployment failed", innerException)
        {
        }
    }
}
