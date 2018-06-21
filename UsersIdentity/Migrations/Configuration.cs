using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using UsersIdentity.Infrastructure;
using UsersIdentity.Models;

namespace UsersIdentity.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<UsersIdentity.Infrastructure.AppIdentityDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "UsersIdentity.Infrastructure.AppIdentityDbContext";
        }

        protected override void Seed(UsersIdentity.Infrastructure.AppIdentityDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var userMgr = new AppUserManager(new UserStore<AppUser>(context));
            var roleMgr = new AppRoleManager(new RoleStore<AppRole>(context));

            var roleName = "Administrators";
            var userName = "Admin";
            var password = "P@ssw0rd";
            var email = "admin@example.com";

            if (!roleMgr.RoleExists(roleName))
            {
                roleMgr.Create(new AppRole(roleName));
            }

            var roleNameList = new List<string> { "Users", "Employees" };
            roleNameList.ForEach(role =>
            {
                if (!roleMgr.RoleExists(role))
                {
                    roleMgr.Create(new AppRole(role));
                }
            });

            for (int i = 0; i < 4; i++)
            {
                var damonUserName = $"Damon{i}";
                var damonUser = userMgr.FindByName(damonUserName);
                if (damonUser == null)
                {
                    userMgr.Create(new AppUser { UserName = damonUserName, Email = $"Damon{i}@example.com" }, password);
                }
            }

            var user = userMgr.FindByName(userName);
            if (user == null)
            {
                userMgr.Create(new AppUser { UserName = userName, Email = email }, password);
                user = userMgr.FindByName(userName);
            }

            if (!userMgr.IsInRole(user.Id, roleName))
            {
                userMgr.AddToRole(user.Id, roleName);
            }

            //foreach (var dbUser in userMgr.Users)
            //{
            //    dbUser.City = Cities.PARIS;
            //}
            foreach (AppUser dbUser in userMgr.Users)
            {
                if (dbUser.Country == Countries.NONE)
                {
                    dbUser.SetCountryFromCity(dbUser.City);
                }
            }
        }
    }
}