using System.Data.Entity.ModelConfiguration;
using OnlineCatalog.Data.Model;

namespace OnlineCatalog.Data.Core.Configurations
{
    public class UserMap: EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            HasKey(t => t.Id);
            HasRequired<UserInfo>(t => t.UserInfo);

            ToTable("AspNetUsers");
        }
    }
}
