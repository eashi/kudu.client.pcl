using Kudu.Core.PCL.SourceControl;

namespace Kudu.Contracts.PCL.SourceControl
{
    public interface IRepositoryFactory
    {
        IRepository EnsureRepository(RepositoryType repositoryType);
        IRepository GetRepository();
        IRepository GetCustomRepository();
    }
}
