using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using UsersIdentity.Models;

namespace UsersIdentity.Infrastructure
{
    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {
        public AppIdentityDbContext() : base("IdentityDb")
        {
        }

        static AppIdentityDbContext()
        {
            System.Data.Entity.Database.SetInitializer<AppIdentityDbContext>(new IdentityDbInit());
        }

        public static AppIdentityDbContext Create()
        {
            return new AppIdentityDbContext();
        }
    }

    public class IdentityDbInit : NullDatabaseInitializer<AppIdentityDbContext>
    {
    }

    //public class IdentityDbInit : DropCreateDatabaseIfModelChanges<AppIdentityDbContext>
    //{
    //    protected override void Seed(AppIdentityDbContext context)
    //    {
    //        PerformInitialSetup(context);
    //        base.Seed(context);
    //    }

    //    public void PerformInitialSetup(AppIdentityDbContext context)
    //    {
    //        // initial configuration will go here
    //        // 初始化配置将放在这儿
    //        var userMgr = new AppUserManager(new UserStore<AppUser>(context));
    //        var roleMgr = new AppRoleManager(new RoleStore<AppRole>(context));

    //        var roleName = "Administrators";
    //        var userName = "Admin";
    //        var password = "P@ssw0rd";
    //        var email = "admin@example.com";

    //        if (!roleMgr.RoleExists(roleName))
    //        {
    //            roleMgr.Create(new AppRole(roleName));
    //        }

    //        var roleNameList = new List<string> { "Users", "Employees" };
    //        roleNameList.ForEach(role =>
    //        {
    //            if (!roleMgr.RoleExists(role))
    //            {
    //                roleMgr.Create(new AppRole(role));
    //            }
    //        });

    //        for (int i = 0; i < 4; i++)
    //        {
    //            var damonUserName = $"Damon{i}";
    //            var damonUser = userMgr.FindByName(damonUserName);
    //            if (damonUser == null)
    //            {
    //                userMgr.Create(new AppUser { UserName = damonUserName, Email = $"Damon{i}@example.com" }, password);
    //            }
    //        }

    //        var user = userMgr.FindByName(userName);
    //        if (user == null)
    //        {
    //            userMgr.Create(new AppUser { UserName = userName, Email = email }, password);
    //            user = userMgr.FindByName(userName);
    //        }

    //        if (!userMgr.IsInRole(user.Id, roleName))
    //        {
    //            userMgr.AddToRole(user.Id, roleName);
    //        }
    //    }
    //}
}