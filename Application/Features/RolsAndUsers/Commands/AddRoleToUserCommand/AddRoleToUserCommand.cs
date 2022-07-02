using Application.Interfaces;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.RolsAndUsers.Commands.AddRoleToUserCommand
{
    public class AddRoleToUserCommand : IRequest<Response<string>>
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
    }

    public class AddRoleToUserCommandHandler : IRequestHandler<AddRoleToUserCommand, Response<string>>
    {
        private readonly IRoleService _rolService;

        public AddRoleToUserCommandHandler(IRoleService rolService)
        {
            _rolService = rolService;
        }

        public async Task<Response<string>> Handle(AddRoleToUserCommand request, CancellationToken cancellationToken)
        {
            return await _rolService.AddRoleToUserAsync(request.UserId, request.RoleId);
        }
    }
}
