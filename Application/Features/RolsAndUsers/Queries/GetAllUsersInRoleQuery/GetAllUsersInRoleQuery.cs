using Application.DTOs.RolsAndUsers;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.RolsAndUsers.Queries.GetAllUsersInRoleQuery
{
    public class GetAllUsersInRoleQuery : IRequest<PageResponse<List<UserInRoleDTO>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Name { get; set; }
    }

    public class GetAllUsersInRoleQueryHandler : IRequestHandler<GetAllUsersInRoleQuery, PageResponse<List<UserInRoleDTO>>>
    {
        public Task<PageResponse<List<UserInRoleDTO>>> Handle(GetAllUsersInRoleQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
