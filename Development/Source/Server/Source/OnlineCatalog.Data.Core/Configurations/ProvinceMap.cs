using System.Data.Entity.ModelConfiguration;
using OnlineCatalog.Data.Model;

namespace OnlineCatalog.Data.Core.Configurations
{
    public class ProvinceMap: EntityTypeConfiguration<Province>
    {
        public ProvinceMap()
        {
            HasKey(t => t.Id);
            Property(t => t.Name).IsRequired().HasMaxLength(128);
        }
    }
}
