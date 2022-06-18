using Application.Enums;
using Identity.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Seeds
{
    public class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager) 
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.basic.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.user.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.superAdmin.ToString()));
        }
    }
}
