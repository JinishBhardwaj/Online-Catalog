using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using OnlineCatalog.Data.Model;
using OnlineCatalog.Service.Contracts;
using OnlineCatalog.Service.Identity;
using Repository.Persistence;

namespace OnlineCatalog.Service.Implementations
{
    public class UserService: BaseService, IUserService
    {
        #region Private members

        private ApplicationUserManager userManager;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class
        /// </summary>
        /// <param name="unitOfWork">Gets the UnitOfWork</param>
        public UserService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the ApplciationUserManager
        /// </summary>
        public ApplicationUserManager UserManager
        {
            get { return HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            set { userManager = value; }
        }

        #endregion

        #region IUserService Members

        /// <summary>
        /// Gets a user with the specified username
        /// </summary>
        /// <param name="username">Username of the user to find</param>
        /// <param name="password">Users password</param>
        /// <returns>User</returns>
        public async Task<User> FindUser(string username, string password)
        {
            var user = await UserManager.FindAsync(username, password);
            return user;
        }

        /// <summary>
        /// Gets the users role
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns>User role name</returns>
        public async Task<string> GetUserRole(string id)
        {
            var user = await UserManager.FindByIdAsync(id);
            if (user != null)
            {
                var role = await UserManager.GetRolesAsync(user.Id);
                return role.FirstOrDefault();
            }
            return string.Empty;
        }

        #endregion
    }
}
