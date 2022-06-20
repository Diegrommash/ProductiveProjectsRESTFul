using Application.DTOs.User;
using Application.Features.Users.Commands.AuthenticateUserCommand;
using Application.Features.Users.Commands.RegisterUserCommand;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseApiController
    {
        [HttpPost("Authenticate")]
        public async Task<IActionResult> AuthenticateAsync(AuthenticationRequest request) 
        {
            return Ok(await Mediator.Send(new AuthenticateUserCommand
            {
                Email = request.Email,
                Password = request.Password,
                IpAddress = GenerateIpAddress(),
            }));
        }


        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync(RegisterRequest request) 
        {
            return Ok(await Mediator.Send(new RegisterUserCommand
            {
                Name = request.Name,
                LastName = request.LastName,
                Email = request.Email,
                UserName = request.UserName,
                Password = request.Password,
                ConfirmPassword = request.ConfirmPassword,           
                Origin = Request.Headers["origin"]
            }));
        }

        private string GenerateIpAddress()
        {
            if(Request.Headers.ContainsKey("X-Forwarded-For"))
            {
                return Request.Headers["X-Forwarded-For"];
            }
            else
            {
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            }
        }
    }
}
