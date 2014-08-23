using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineCatalog.Data.Model;

namespace OnlineCatalog.Data.Core
{
    public class OnlineCatalogContext: IdentityDbContext<User>
    {
        #region Constructors

        public OnlineCatalogContext() : base("DefaultConnection", throwIfV1Schema:true) { }
        static OnlineCatalogContext() { Database.SetInitializer<OnlineCatalogContext>(new DropCreateDatabaseIfModelChanges<OnlineCatalogContext>()); }

        #endregion

        #region Methods

        public new DbSet<TEntity> Set<TEntity>() where TEntity : class { return base.Set<TEntity>(); }
        public static OnlineCatalogContext Create() { return new OnlineCatalogContext(); }

        #endregion

        #region Overrides of DbContext

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasKey(t => t.Id).ToTable("AspNetRoles");
            modelBuilder.Entity<IdentityUserRole>().HasKey(t => new { t.RoleId, t.UserId }).ToTable("AspNetUserRoles");
            modelBuilder.Entity<IdentityUserLogin>().HasKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId }).ToTable("AspNetUserLogins");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("AspNetUserClaims");
            modelBuilder.Configurations.AddFromAssembly(typeof(OnlineCatalog.Data.Core.Configurations.UserMap).Assembly);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            
            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}
