using System.Threading.Tasks;
using Repository.DataAccess;

namespace Repository.Persistence
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
        IRepository<TEntity> RepositoryFor<TEntity>() where TEntity : class, new();
    }
}
