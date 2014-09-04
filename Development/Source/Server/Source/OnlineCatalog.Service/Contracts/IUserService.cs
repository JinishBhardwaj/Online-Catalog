using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using OnlineCatalog.Data.Model;

namespace OnlineCatalog.Service.Contracts
{
    public interface IUserService
    {
        Task<User> FindUser(string username, string password);
        Task<string> GetUserRole(string id);
        Task<IdentityResult> CreateUser(User user, string password);
    }
}
