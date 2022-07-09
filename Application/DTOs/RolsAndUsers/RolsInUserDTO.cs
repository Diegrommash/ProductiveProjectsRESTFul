using Application.DTOs.RolsAndUsers.List;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.RolsAndUsers
{
    public class RolsInUserDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }

        public IList<RoleForListDTO> Rols { get; set; }
        
        //public ICollection<ApplicationUserRole> UserRoles { get; set; }

        //public ICollection<ApplicationRole> Rols { get; set; }
    }
}
