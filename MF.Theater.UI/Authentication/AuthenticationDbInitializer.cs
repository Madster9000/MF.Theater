﻿using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MF.Theater.UI.Authentication
{
    public class AuthenticationDbInitializer: DropCreateDatabaseAlways<ApplicationDbContext>
//CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            userManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 1,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var adminRole = new IdentityRole{Name = "admin"};
            var userRole = new IdentityRole { Name = "user" };

            roleManager.Create(adminRole);
            roleManager.Create(userRole);

            var admin = new ApplicationUser{Email = "admin@admin.ru", UserName = "admin"};

            var userCreationResult = userManager.Create(admin, "admin");

            if (userCreationResult.Succeeded)
            {
                userManager.AddToRole(admin.Id, adminRole.Name);
                userManager.AddToRole(admin.Id, userRole.Name);
            }
            base.Seed(context);
        }
    }
}