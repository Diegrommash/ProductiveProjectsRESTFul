using Application.Wrappers;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRoleService
    {
        Task<Response<string>> AddRoleToUserAsync(string userId, string roleId);
        Task<Response<string>> RemoveRoleFromUserAsync(string userId, string roleId);
    }
}
