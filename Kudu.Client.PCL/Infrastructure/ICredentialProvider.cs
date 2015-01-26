using System.Net;

namespace Kudu.Client.PCL.Infrastructure
{
    public interface ICredentialProvider
    {
        ICredentials GetCredentials();
    }
}
