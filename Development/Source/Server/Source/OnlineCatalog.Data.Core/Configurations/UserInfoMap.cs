using System.Data.Entity.ModelConfiguration;
using OnlineCatalog.Data.Model;

namespace OnlineCatalog.Data.Core.Configurations
{
    public class UserInfoMap: EntityTypeConfiguration<UserInfo>
    {
        public UserInfoMap()
        {
            HasKey(t => t.Id);
            Property(t => t.Firstname).IsRequired().HasMaxLength(128);
            Property(t => t.Lastname).IsRequired().HasMaxLength(128);
            Property(t => t.AddressLine1).IsRequired().HasMaxLength(128);
            Property(t => t.City).IsRequired().HasMaxLength(128);
            Property(t => t.Pincode).IsRequired().HasMaxLength(10);

            HasRequired<Province>(t => t.Province);
        }
    }
}
