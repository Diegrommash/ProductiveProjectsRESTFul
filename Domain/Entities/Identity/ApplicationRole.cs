using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Identity
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole(string name) : base(name) 
        {

        }
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
