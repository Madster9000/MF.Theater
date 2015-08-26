using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MF.Theater.UI.Authentication
{
    public class AuthenticationDbInitializer: 
        //DropCreateDatabaseAlways<ApplicationDbContext>
CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            using (var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context)))
            {
                userManager.PasswordValidator = new PasswordValidator
                {
                    RequiredLength = 1,
                    RequireNonLetterOrDigit = false,
                    RequireDigit = false,
                    RequireLowercase = false,
                    RequireUppercase = false,
                };
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

                var adminRole = new IdentityRole { Name = "admin" };

                roleManager.Create(adminRole);

                var admin = new ApplicationUser { Email = "admin@admin.ru", UserName = "admin@admin.ru", EmailConfirmed = true };

                var userCreationResult = userManager.Create(admin, "admin");

                if (userCreationResult.Succeeded)
                {
                    userManager.AddToRole(admin.Id, adminRole.Name);
                }
                
            }

            base.Seed(context);
        }
    }
}