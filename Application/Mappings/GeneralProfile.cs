using Application.DTOs;
using Application.Features.TypeMeasurementUnits.Commands.CreateTypeMeasurementUnitCommand;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region DTOs
            CreateMap<TypeMeasurementUnit, TypeMeasurementUnitDto>();
            #endregion

            #region Commands
            CreateMap<CreateTypeMeasurementUnitCommand, TypeMeasurementUnit>();
            #endregion
        }

    }
}
