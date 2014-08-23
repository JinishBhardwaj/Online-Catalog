namespace OnlineCatalog.Data.Core.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using OnlineCatalog.Infrastructure.Enums;
    using OnlineCatalog.Infrastructure.Helpers;

    internal sealed class Configuration : DbMigrationsConfiguration<OnlineCatalog.Data.Core.OnlineCatalogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(OnlineCatalog.Data.Core.OnlineCatalogContext context)
        {
            //var roles = EnumHelper.Names<RoleType>();
            //foreach (var role in roles)
            //{
            //    context.Roles.Add(new IdentityRole(role));
            //}
        }
    }
}
