using System.Threading.Tasks;

namespace Repository.DataAccess
{
    public interface IRepository<TEntity> where TEntity: class
    {
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Delete(object id);
        Task<TEntity> FindAsync(params object[] keyValues);
        IQuery<TEntity> Query();
    }
}
