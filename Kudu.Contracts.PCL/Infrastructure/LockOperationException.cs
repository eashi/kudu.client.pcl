using System;

namespace Kudu.Contracts.PCL.Infrastructure
{
    public class LockOperationException : InvalidOperationException
    {
        public LockOperationException(string message)
            : base(message)
        {
        }
    }
}
