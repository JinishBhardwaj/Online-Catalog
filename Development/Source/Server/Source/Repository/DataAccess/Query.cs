using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository.DataAccess
{
    public class Query<TEntity>: IQuery<TEntity> where TEntity: class
    {
        #region Private members

        private Expression<Func<TEntity, bool>> filterExpression;
        private List<Expression<Func<TEntity, object>>> expression;
        private readonly Repository<TEntity> repository;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Query"/> class
        /// </summary>
        /// <exception cref="ArgumentNullException">Repository must not be null</exception>
        public Query(Repository<TEntity> repository)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");
            this.repository = repository;
        }

        #endregion

        #region IQuery<TEntity> Members

        /// <summary>
        /// Specifies the filter to be applied while fetching data
        /// </summary>
        /// <param name="filterExpression">Filter expression</param>
        /// <returns>Query</returns>
        public Query<TEntity> FilterBy(Expression<Func<TEntity, bool>> filterExpression)
        {
            this.filterExpression = filterExpression;
            return this;
        }

        /// <summary>
        /// Specifies the navigation properties to be included while fetching an entity
        /// </summary>
        /// <param name="expression">Included properties expression</param>
        /// <returns>Query</returns>
        public Query<TEntity> Include(List<Expression<Func<TEntity, object>>> expression)
        {
            this.expression = expression;
            return this;
        }

        /// <summary>
        /// Gets all the records from the database for the TEntity
        /// </summary>
        /// <returns>List of records from the database for an entity</returns>
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await repository.GetAllAsync(filterExpression, expression);
        }

        #endregion
    }
}
