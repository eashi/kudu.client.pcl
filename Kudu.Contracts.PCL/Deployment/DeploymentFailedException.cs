using System;

namespace Kudu.Core.PCL.Deployment
{
    public class DeploymentFailedException : InvalidOperationException
    {
        public DeploymentFailedException(Exception innerException)
            : base("Deployment failed", innerException)
        {
        }
    }
}
