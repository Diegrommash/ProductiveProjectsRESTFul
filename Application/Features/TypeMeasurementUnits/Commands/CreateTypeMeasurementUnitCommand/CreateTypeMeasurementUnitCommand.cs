using Application.Interfaces;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities.Application;

namespace Application.Features.TypeMeasurementUnits.Commands.CreateTypeMeasurementUnitCommand
{
    public class CreateTypeMeasurementUnitCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class CreateTypeMeasurementUnitCommandHander : IRequestHandler<CreateTypeMeasurementUnitCommand, Response<int>>
    {
        private readonly IRepositoryAsync<TypeMeasurementUnit> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateTypeMeasurementUnitCommandHander(IMapper mapper, IRepositoryAsync<TypeMeasurementUnit> repositoryAsync)
        {
            _mapper = mapper;
            _repositoryAsync = repositoryAsync;
        }

        public  async Task<Response<int>> Handle(CreateTypeMeasurementUnitCommand request, CancellationToken cancellationToken)
        {
            var newRecord = _mapper.Map<TypeMeasurementUnit>(request);
            var data = await _repositoryAsync.AddAsync(newRecord);

            return new Response<int>(data.Id);
        }
    }
}
