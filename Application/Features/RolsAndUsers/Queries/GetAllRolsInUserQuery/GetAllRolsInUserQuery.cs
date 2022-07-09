using Application.DTOs.RolsAndUsers;
using Application.Interfaces;
using Application.Specifications.Identity;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.RolsAndUsers.Queries.GetAllRolsInUserQuery
{
    public class GetAllRolsInUserQuery : IRequest<Response<RolsInUserDTO>>
    {
        public string UserId { get; set; }
    }

    public class GetAllRolsInUserQueryHandler : IRequestHandler<GetAllRolsInUserQuery, Response<RolsInUserDTO>>
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public GetAllRolsInUserQueryHandler(IRoleService roleService, IMapper mapper)
        {        
            _roleService = roleService; 
            _mapper = mapper;
        }

        public async Task<Response<RolsInUserDTO>> Handle(GetAllRolsInUserQuery request, CancellationToken cancellationToken)
        {

            var rolsInUser = await _roleService.GetAllRolsInUserAsync(request.UserId);
            var rolsInUserDTO = _mapper.Map<RolsInUserDTO>(rolsInUser.Data);
            return new Response<RolsInUserDTO>(rolsInUserDTO);
        }
    }
}
