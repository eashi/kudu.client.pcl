using System;

namespace Kudu.Core.PCL.Hooks
{
    public class ConflictException : InvalidOperationException
    {
        public ConflictException()
            : base()
        {
        }
    }
}
