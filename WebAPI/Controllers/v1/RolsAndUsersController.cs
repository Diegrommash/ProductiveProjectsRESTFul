using Application.Features.RolsAndUsers.Commands.AddRoleToUserCommand;
using Application.Features.RolsAndUsers.Commands.RemoveRoleFromUserCommand;
using Application.Features.RolsAndUsers.Queries.GetAllRolsInUserQuery;
using Application.Features.RolsAndUsers.Queries.GetAllUsersInRoleQuery;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolsAndUsersController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> AddRoleToUser(AddRoleToUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveRoleFromUser(RemoveRoleFromUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("rolsInUser/userId")]
        public async Task<IActionResult> GetAllRolsInUser(string userId)
        {
            return Ok(await Mediator.Send(new GetAllRolsInUserQuery {UserId = userId}));
        }

        [HttpGet("usersInRole/roleId")]
        public async Task<IActionResult> GetAllUserInRole(string roleId)
        {
            return Ok(await Mediator.Send(new GetAllUsersInRoleQuery { RoleId = roleId }));
        }
    }
}
