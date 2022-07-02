using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Identity.Services
{
    public class RoleService : IRoleService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public RoleService(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<Response<string>> AddRoleToUserAsync(string userId, string roleId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if(user == null)
            {
                throw new ApiException($"No existe un usuario con el Id {userId}.");
            }

            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                throw new ApiException($"No existe un rol con el Id {roleId}.");
            }

            var roleInUser = await _userManager.IsInRoleAsync(user, role.Name);
            if (roleInUser) 
            {
                throw new ApiException($"El usuerio {user.Name} ya posee el rol de {role.Name}.");
            }

            var result = await _userManager.AddToRoleAsync(user, role.Name);
            if (result.Succeeded)
            {
                return new Response<string>($"El rol {role.Name} fue agregado correctamente al usuario {user.Name}.");
            }
            else
            {
                throw new ApiException($"{result.Errors}.");
            }

        }

        public async Task<Response<string>> RemoveRoleFromUserAsync(string userId, string roleId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new ApiException($"No existe un usuario con el Id {userId}.");
            }

            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                throw new ApiException($"No existe un rol con el Id {roleId}.");
            }

            var roleInUser = await _userManager.IsInRoleAsync(user, role.Name);
            if (!roleInUser)
            {
                throw new ApiException($"El usuerio {user.Name} no posee el rol de {role.Name}.");
            }

            var result = await _userManager.RemoveFromRoleAsync(user, role.Name);
            if (result.Succeeded)
            {
                return new Response<string>($"El rol {role.Name} fue eliminado del usuario {user.Name}.");
            }
            else
            {
                throw new ApiException($"{result.Errors}.");
            }
        }
    }
}
