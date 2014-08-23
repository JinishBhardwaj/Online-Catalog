using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace OnlineCatalog.Data.Model
{
    public class User: IdentityUser
    {
        public int UserInfoId { get; set; }
        public virtual UserInfo UserInfo { get; set; }

        #region Methods
        
        public async Task<ClaimsIdentity> GenerateIdentityAsync(UserManager<User> manager)
        {
            var identity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ExternalCookie);
            return identity;
        }

        #endregion
    }
}
