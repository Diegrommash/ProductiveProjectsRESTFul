using Application.DTOs.RolsAndUsers.List;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.RolsAndUsers
{
    public class UsersInRoleDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public IList<UserForListDTO> Users { get; set; }
    }
}
