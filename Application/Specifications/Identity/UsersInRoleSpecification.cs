using Ardalis.Specification;
using Domain.Entities.Identity;

namespace Application.Specifications.Identity
{
    public class UsersInRoleSpecification : Specification<ApplicationRole>
    {
        public UsersInRoleSpecification(string roleId)
        {
            Query.Include(ar => ar.UserRoles).ThenInclude(ur => ur.User);
            Query.Where(ar => ar.Id == roleId);
        }
    }
}
