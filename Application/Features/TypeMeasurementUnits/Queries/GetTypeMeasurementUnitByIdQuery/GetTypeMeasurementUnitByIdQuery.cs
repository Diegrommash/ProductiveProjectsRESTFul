using Application.DTOs.TypeMeasurementUnit;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Application;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.TypeMeasurementUnits.Queries.GetTypeMeasurementUnitByIdQuery
{
    public class GetTypeMeasurementUnitByIdQuery : IRequest<Response<TypeMeasurementUnitDto>>
    {
        public int Id { get; set; }

        public class GetTypeMeasurementUnitByIdQueryHandler : IRequestHandler<GetTypeMeasurementUnitByIdQuery, Response<TypeMeasurementUnitDto>>
        { 
            private readonly IRepositoryAsync<TypeMeasurementUnit> _repositoryAsync;
            private readonly IMapper _mapper;

            public GetTypeMeasurementUnitByIdQueryHandler(IMapper mapper, IRepositoryAsync<TypeMeasurementUnit> repositoryAsync)
            {
                _mapper = mapper;
                _repositoryAsync = repositoryAsync;
            }

            public async Task<Response<TypeMeasurementUnitDto>> Handle(GetTypeMeasurementUnitByIdQuery request, CancellationToken cancellationToken)
            {
                var record = await _repositoryAsync.GetByIdAsync(request.Id);

                if (record == null)
                {
                    throw new KeyNotFoundException($"Registro con Id {request.Id} no encontrado");
                }
                else
                {
                    var dto = _mapper.Map<TypeMeasurementUnitDto>(record);
                    return new Response<TypeMeasurementUnitDto>(dto);
                }
            }
        }
    }
}
