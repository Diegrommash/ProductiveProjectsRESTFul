using Application.Exceptions;
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

namespace Application.Features.TypeMeasurementUnits.Commands.UpdateTypeMeasurementUnitCommand
{
    public class UpdateTypeMeasurementUnitCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class CreateTypeMeasurementUnitCommandHander : IRequestHandler<UpdateTypeMeasurementUnitCommand, Response<int>>
    {
        private readonly IRepositoryAsync<TypeMeasurementUnit> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateTypeMeasurementUnitCommandHander(IMapper mapper, IRepositoryAsync<TypeMeasurementUnit> repositoryAsync)
        {
            _mapper = mapper;
            _repositoryAsync = repositoryAsync;
        }
        public async Task<Response<int>> Handle(UpdateTypeMeasurementUnitCommand request, CancellationToken cancellationToken)
        {
            var record = await _repositoryAsync.GetByIdAsync(request.Id);

            if (record == null)
            {
                throw new KeyNotFoundException($"Registro con Id {request.Id} no encontrado");
            }
            else
            {
                record.Name = request.Name;
                record.Description = request.Description;

                await _repositoryAsync.UpdateAsync(record);

                return new Response<int>(record.Id);
            }

        }
    }
  
}
