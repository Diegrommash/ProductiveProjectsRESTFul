using Application.Interfaces;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.RolsAndUsers.Commands.RemoveRoleFromUserCommand
{
    public class RemoveRoleFromUserCommand : IRequest<Response<string>>
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
    }

    public class RemoveRoleFromUserCommandHandler : IRequestHandler<RemoveRoleFromUserCommand, Response<string>>
    {
        private readonly IRoleService _rolService;

        public RemoveRoleFromUserCommandHandler(IRoleService rolService)
        {
            _rolService = rolService;
        }

        public async Task<Response<string>> Handle(RemoveRoleFromUserCommand request, CancellationToken cancellationToken)
        {
            return await _rolService.RemoveRoleFromUserAsync(request.UserId, request.RoleId);
        }

    
    }
}
