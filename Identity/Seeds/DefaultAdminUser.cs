using Application.Enums;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Seeds
{
    public class DefaultAdminUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            var defaultUser = new ApplicationUser
            {
                //Id = "3",
                UserName = "adminUserName",
                Email = "admin@admin.com",
                Name = "adminName",
                LastName = "adminLastName",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            if(userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if(user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123Pa$$word");
                    await userManager.AddToRoleAsync(defaultUser, Roles.admin.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Roles.user.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Roles.basic.ToString());
                }
            }
        }
    }
}
