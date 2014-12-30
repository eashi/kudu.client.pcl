using System;
using Kudu.Contracts.PCL.Infrastructure;

namespace Kudu.Core.PCL.Deployment
{
    public interface IDeploymentStatusManager
    {
        IDeploymentStatusFile Create(string id);
        IDeploymentStatusFile Open(string id);
        void Delete(string id);

        IOperationLock Lock { get; }

        string ActiveDeploymentId { get; set; }

        DateTime LastModifiedTime { get; }
    }
}
