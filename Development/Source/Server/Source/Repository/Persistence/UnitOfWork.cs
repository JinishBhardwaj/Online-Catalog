using System;
using System.Collections;
using System.Data.Entity;
using System.Threading.Tasks;
using Repository.DataAccess;

namespace Repository.Persistence
{
    public class UnitOfWork: IUnitOfWork
    {
        #region Private members

        private readonly DbContext context;
        private Hashtable repositoryCollection;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class
        /// </summary>
        /// <param name="context">DbContex to use for data persistence</param>
        /// <exception cref="ArgumentNullException">DbContext must not be null</exception>
        public UnitOfWork(DbContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            this.context = context;
        }

        #endregion

        #region IUnitOfWork Members

        /// <summary>
        /// Persists the changes to the database
        /// </summary>
        /// <returns>Task</returns>
        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Gets a repository for the type TEntity. If the repository is present in the 
        /// existing repositories collection then gets it from the collection, else
        /// creates a new repository of the type
        /// </summary>
        /// <typeparam name="TEntity">Entity type for which repository is to be created</typeparam>
        /// <returns>IRepository of type TEntity</returns>
        public IRepository<TEntity> RepositoryFor<TEntity>() where TEntity : class, new()
        {
            repositoryCollection = repositoryCollection ?? new Hashtable();
            var type = typeof(TEntity).Name;
            if (repositoryCollection.ContainsKey(type))
            {
                return (IRepository<TEntity>)repositoryCollection[type];
            }
            var repository = typeof(Repository<TEntity>);
            repositoryCollection.Add(type, Activator.CreateInstance(repository.MakeGenericType(typeof(TEntity)), context));
            return (IRepository<TEntity>)repositoryCollection[type];
        }

        #endregion
    }
}
