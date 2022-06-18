using Application.DTOs.User;
using Application.Enums;
using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using Domain.Settings;
using Identity.Models;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace Identity.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JWTSettings _jWTSettings;
        private readonly IDateTimeService _dateTimeService;

        public AccountService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager, JWTSettings jWTSettings, IDateTimeService dateTimeService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _jWTSettings = jWTSettings;
            _dateTimeService = dateTimeService;
        }

        public async Task<Response<AuthenticationResponse>> AythenticateAsync(AuthenticationRequest request, string ipAddress)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if(user == null)
            {
                throw new ApiException($"No hay cuenta registrada con el email: {request.Email}.");
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                throw new ApiException($"Las credenciales no son validas {request.Email}.");
            }

            JwtSecurityToken jwtSecurityToken = await GenerateJWTToken(user);

        }

        public async Task<Response<string>> RegisterAsync(RegisterRequest request, string origin)
        {
            var userWithTheSameName = await _userManager.FindByNameAsync(request.UserName);
            if (userWithTheSameName != null)
            {
                throw new ApiException($"¡El nombre de usuario: {request.UserName}, ya fue registrado¡.");
            }
          
            var userWithSameEmail = await _userManager.FindByEmailAsync(request.Email);
            if(userWithSameEmail != null)
            {
                throw new ApiException($"¡El email: {request.Email}, ya fue registrado!.");
            }

            var user = new ApplicationUser
            {
                UserName = request.UserName,
                Name = request.Name,
                LastName = request.LastName,
                Email = request.Email,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, Roles.basic.ToString());
                return new Response<string>(user.Id, message: $"Usuario registrado correctamente. {request.UserName}");
            }
            else
            {
                throw new ApiException($"{result.Errors}.");
            }
        }

        private async Task<JwtSecurityToken> GenerateJWTToken(ApplicationUser user)
        {

        }
    }
}
