using System;

namespace Kudu.Contracts.PCL.Hooks
{
    public class ConflictException : InvalidOperationException
    {
        public ConflictException()
            : base()
        {
        }
    }
}
