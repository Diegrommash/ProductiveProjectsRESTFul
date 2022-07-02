using Application.Enums;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Identity.Seeds
{
    public class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager) 
        {
            await roleManager.CreateAsync(new ApplicationRole(Roles.basic.ToString()));
            await roleManager.CreateAsync(new ApplicationRole(Roles.user.ToString()));
            await roleManager.CreateAsync(new ApplicationRole(Roles.admin.ToString()));
            await roleManager.CreateAsync(new ApplicationRole(Roles.superAdmin.ToString()));
        }
    }
}
