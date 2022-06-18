using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.TypeMeasurementUnits.Commands.DeleteTypeMeasurementUnitCommand
{
    public class DeleteTypeMeasurementUnitCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
   
    }

    public class CreateTypeMeasurementUnitCommandHander : IRequestHandler<DeleteTypeMeasurementUnitCommand, Response<int>>
    {
        private readonly IRepositoryAsync<TypeMeasurementUnit> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateTypeMeasurementUnitCommandHander(IMapper mapper, IRepositoryAsync<TypeMeasurementUnit> repositoryAsync)
        {
            _mapper = mapper;
            _repositoryAsync = repositoryAsync;
        }
        public async Task<Response<int>> Handle(DeleteTypeMeasurementUnitCommand request, CancellationToken cancellationToken)
        {
            var record = await _repositoryAsync.GetByIdAsync(request.Id);

            if (record == null)
            {
                throw new KeyNotFoundException($"Registro con Id {request.Id} no encontrado");
            }
            else
            {
                await _repositoryAsync.DeleteAsync(record);

                return new Response<int>(record.Id);
            }

        }
    }
}
