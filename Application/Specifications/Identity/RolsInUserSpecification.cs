using Ardalis.Specification;
using Domain.Entities.Identity;

namespace Application.Specifications.Identity
{
    public class RolsInUserSpecification : Specification<ApplicationUser>
    {
        public RolsInUserSpecification(string userId)
        {
            Query.Include(au => au.UserRoles).ThenInclude(aur => aur.Role);
            Query.Where(x => x.Id == userId);
        }
    }
}
