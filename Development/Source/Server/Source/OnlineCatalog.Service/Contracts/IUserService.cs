using System.Threading.Tasks;
using OnlineCatalog.Data.Model;

namespace OnlineCatalog.Service.Contracts
{
    public interface IUserService
    {
        Task<User> FindUser(string username, string password);
        Task<string> GetUserRole(string id);
    }
}
