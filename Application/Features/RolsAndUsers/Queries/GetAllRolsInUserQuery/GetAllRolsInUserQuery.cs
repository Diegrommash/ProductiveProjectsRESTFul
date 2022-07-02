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
    public class GetAllRolsInUserQuery : IRequest<PageResponse<List<RolsInUserDTO>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
    }

    public class GetAllRolsInUserQueryHandler : IRequestHandler<GetAllRolsInUserQuery, PageResponse<List<RolsInUserDTO>>>
    {
        private readonly IReadRepositoryAsync<ApplicationUser> _repositoryAsync;
        private readonly IDistributedCache _distributedCache;
        private readonly IMapper _mapper;

        public GetAllRolsInUserQueryHandler(IDistributedCache distributedCache, IMapper mapper, IReadRepositoryAsync<ApplicationUser> repositoryAsync)
        {
            _distributedCache = distributedCache;
            _mapper = mapper;
            _repositoryAsync = repositoryAsync;
        }

        public async Task<PageResponse<List<RolsInUserDTO>>> Handle(GetAllRolsInUserQuery request, CancellationToken cancellationToken)
        {

            var cachekey = $"RolsInUserDtoList_{request.PageNumber}_{request.PageSize}_{request.UserId}_{request.Name}";
            string serializedRolsInUserDtoList;
            var rolsInUserList = new List<ApplicationUser>();
            var rolsInUserDtoList = new List<RolsInUserDTO>();

            var redisRolsInUserDtoList = await _distributedCache.GetAsync(cachekey);
            if (redisRolsInUserDtoList != null)
            {
                serializedRolsInUserDtoList = Encoding.UTF8.GetString(redisRolsInUserDtoList);
                rolsInUserDtoList = JsonConvert.DeserializeObject<List<RolsInUserDTO>>(serializedRolsInUserDtoList);
            }
            else
            {
                rolsInUserList = await _repositoryAsync.ListAsync(new PageRolsInUserSpecification(request.PageNumber, request.PageSize, request.UserId, request.Name));
                rolsInUserDtoList = _mapper.Map<List<RolsInUserDTO>>(rolsInUserList);
                serializedRolsInUserDtoList = JsonConvert.SerializeObject(rolsInUserDtoList);
                redisRolsInUserDtoList = Encoding.UTF8.GetBytes(serializedRolsInUserDtoList);

                var options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(2));

                await _distributedCache.SetAsync(cachekey, redisRolsInUserDtoList, options);
            }

            //var rolsInUser = _mapper.Map<List<RolsInUserDTO>>(rolsInUserList);

            return new PageResponse<List<RolsInUserDTO>>(rolsInUserDtoList, request.PageNumber, request.PageSize);
        }
    }
}
