using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository.DataAccess
{
    public class Repository<TEntity>: IRepository<TEntity> where TEntity: class
    {
        #region Private members

        private readonly DbContext context;
        private DbSet<TEntity> dbSet;

        #endregion

        #region Construcors

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository"/> class
        /// </summary>
        /// <param name="context">DbContext to use for data access</param>
        /// <exception cref="ArgumentNullException">DbContext must not be null</exception>
        public Repository(DbContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        #endregion

        #region IRepository<TEntity> Members

        /// <summary>
        /// Inserts a new record into the context
        /// </summary>
        /// <param name="entity">Record to insert</param>
        public void Insert(TEntity entity)
        {
            dbSet.Add(entity);
            context.Entry(entity).State = EntityState.Added;
        }

        /// <summary>
        /// Updates an existing record in the context
        /// </summary>
        /// <param name="entity">Record to update</param>
        public void Update(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Deletes an existing record from the context
        /// </summary>
        /// <param name="entity">Record to delete</param>
        public void Delete(TEntity entity)
        {
            dbSet.Remove(entity);
            context.Entry(entity).State = EntityState.Deleted;
        }

        /// <summary>
        /// Deletes an existing record from the context
        /// </summary>
        /// <param name="id">Unique identifier of the record to delete</param>
        public void Delete(object id)
        {
            var entity = dbSet.Find(id);
            Delete(entity);
        }

        /// <summary>
        /// Gets a record from the context with the provided key values
        /// </summary>
        /// <param name="keyValues">Key values</param>
        /// <returns>Single record</returns>
        public async Task<TEntity> FindAsync(params object[] keyValues)
        {
            return await dbSet.FindAsync(keyValues);
        }

        /// <summary>
        /// Specifies the query parameters while fetching entities from the context
        /// </summary>
        /// <returns>Query</returns>
        public IQuery<TEntity> Query()
        {
            return new Query<TEntity>(this);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets all the records from the context based on the specified query parameters
        /// </summary>
        /// <param name="filterExpression">Filter expression</param>
        /// <param name="expression">Included properties</param>
        /// <returns>List of records for an entity</returns>
        internal async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filterExpression,
                                                              List<Expression<Func<TEntity, object>>> expression)
        {
            IQueryable<TEntity> query = dbSet;
            if (expression != null) { expression.ForEach(q => query = query.Include(q)); }
            if (filterExpression != null) { query.Where(filterExpression); }
            return await query.ToListAsync<TEntity>();
        }   

        #endregion
    }
}
