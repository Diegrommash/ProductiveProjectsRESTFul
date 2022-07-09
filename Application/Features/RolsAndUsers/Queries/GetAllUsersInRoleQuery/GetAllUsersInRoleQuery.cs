using Application.DTOs.RolsAndUsers;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.RolsAndUsers.Queries.GetAllUsersInRoleQuery
{
    public class GetAllUsersInRoleQuery : IRequest<Response<UsersInRoleDTO>>
    {
        public string RoleId { get; set; }
    }

    public class GetAllUsersInRoleQueryHandler : IRequestHandler<GetAllUsersInRoleQuery, Response<UsersInRoleDTO>>
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;
        public GetAllUsersInRoleQueryHandler(IMapper mapper, IRoleService roleService)
        {
            _mapper = mapper;
            _roleService = roleService;
        }

        public async Task<Response<UsersInRoleDTO>> Handle(GetAllUsersInRoleQuery request, CancellationToken cancellationToken)
        {
            var usersInRole = await _roleService.GetAllUsersInRoleAsync(request.RoleId);
            var usersInRoleDTO = _mapper.Map<UsersInRoleDTO>(usersInRole.Data);
            return new Response<UsersInRoleDTO>(usersInRoleDTO);
        }
    }
}
