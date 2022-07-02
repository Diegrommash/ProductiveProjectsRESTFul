using Ardalis.Specification;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities.Identity;

namespace Application.Specifications.Identity
{
    public class PageRolsInUserSpecification : Specification<ApplicationUser>
    {
        public PageRolsInUserSpecification(int pageNumber, int pageSize, string userId, string name)
        {
            //Query.Include(x => x.User);
            Query.Include(x => x.UserRoles).ThenInclude(x => x.Role);
            Query.Where(x => x.Id == userId);

            Query.Skip((pageNumber - 1) * pageSize)
               .Take(pageSize);

            //if (!string.IsNullOrEmpty(name))
              //  Query.Search(x => x, "%" + name + "%");
        }
    }
}
