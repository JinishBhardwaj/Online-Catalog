using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository.DataAccess
{
    public interface IQuery<TEntity> where TEntity: class
    {
        Query<TEntity> FilterBy(Expression<Func<TEntity, bool>> filterExpression);
        Query<TEntity> Include(List<Expression<Func<TEntity, object>>> expression);
        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}
