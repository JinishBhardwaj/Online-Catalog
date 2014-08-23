using System;
using Repository.Persistence;

namespace OnlineCatalog.Service
{
    public abstract class BaseService
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseService"/> class
        /// </summary>
        /// <param name="unitOfWork">Gets UnitOfWork</param>
        /// <exception cref="ArgumentNullException">UnitOfWork must not be null</exception>
        protected BaseService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException("unitOfWork");
            this.UnitOfWork = unitOfWork;
        }

        #endregion

        #region Properties

        public IUnitOfWork UnitOfWork { get; set; }

        #endregion
    }
}
