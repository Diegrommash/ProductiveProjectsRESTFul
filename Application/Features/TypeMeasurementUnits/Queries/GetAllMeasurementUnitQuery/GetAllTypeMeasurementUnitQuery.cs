using Application.DTOs;
using Application.Interfaces;
using Application.Specifications;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.TypeMeasurementUnits.Queries.GetAllMeasurementUnitQuery
{
    public class GetAllTypeMeasurementUnitQuery : IRequest<PageResponse<List<TypeMeasurementUnitDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Name { get; set; }

        public class GetAllTypeMeasurementUnitHandler : IRequestHandler<GetAllTypeMeasurementUnitQuery, PageResponse<List<TypeMeasurementUnitDto>>>
        {
            private readonly IRepositoryAsync<TypeMeasurementUnit> _repositoryAsync;
            private readonly IDistributedCache _distributedCache;
            private readonly IMapper _mapper;

            public GetAllTypeMeasurementUnitHandler(IMapper mapper, IRepositoryAsync<TypeMeasurementUnit> repositoryAsync, IDistributedCache distributedCache)
            {
                _mapper = mapper;
                _repositoryAsync = repositoryAsync;
                _distributedCache = distributedCache;
            }

            public async Task<PageResponse<List<TypeMeasurementUnitDto>>> Handle(GetAllTypeMeasurementUnitQuery request, CancellationToken cancellationToken)
            {
                var cachekey = $"clientList_{request.PageNumber}_{request.PageSize}_{request.Name}";
                string serializedClientList;
                var clientList = new List<TypeMeasurementUnit>();
                var redisClientList = await _distributedCache.GetAsync(cachekey);

                if(redisClientList != null)
                {
                    serializedClientList = Encoding.UTF8.GetString(redisClientList);
                    clientList = JsonConvert.DeserializeObject<List<TypeMeasurementUnit>>(serializedClientList);
                }
                else
                {
                    clientList = await _repositoryAsync.ListAsync(new PageTypeMeasurementUnitSpecification(request.PageNumber, request.PageSize, request.Name));
                    serializedClientList = JsonConvert.SerializeObject(clientList);
                    redisClientList = Encoding.UTF8.GetBytes(serializedClientList);

                    var options = new DistributedCacheEntryOptions()
                        .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                        .SetSlidingExpiration(TimeSpan.FromMinutes(2));

                    await _distributedCache.SetAsync(cachekey, redisClientList, options);
                }

                var clientsDto = _mapper.Map<List<TypeMeasurementUnitDto>>(clientList);

                return new PageResponse<List<TypeMeasurementUnitDto>>(clientsDto, request.PageNumber, request.PageSize);
            }
        }

    }
}
