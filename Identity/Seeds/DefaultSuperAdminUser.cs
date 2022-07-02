using Application.Enums;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Seeds
{
    public class DefaultSuperAdminUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            var defaultUser = new ApplicationUser
            {
                //Id = "4",
                UserName = "superAdminUserName",
                Email = "superAdmin@superAdmin.com",
                Name = "superAdminName",
                LastName = "superAdminLastName",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123Pa$$word");
                    await userManager.AddToRoleAsync(defaultUser, Roles.superAdmin.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Roles.admin.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Roles.user.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Roles.basic.ToString());
                }
            }
        }
    }
}
