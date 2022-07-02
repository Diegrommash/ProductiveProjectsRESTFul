using Application.DTOs.RolsAndUsers;
using Application.DTOs.TypeMeasurementUnit;
using Application.Features.TypeMeasurementUnits.Commands.CreateTypeMeasurementUnitCommand;
using AutoMapper;
using Domain.Entities.Application;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region DTOs
            CreateMap<TypeMeasurementUnit, TypeMeasurementUnitDto>();

            
            #region ApplicationUser and RolsInUserDto

            CreateMap<ApplicationRole, RolsForListDTO>();

            CreateMap<ApplicationUser, RolsInUserDTO>()
                .ForMember(riu => riu.Rols, src =>
                    src.MapFrom(au =>
                        au.UserRoles.Select(ur => ur.Role)
                            .ToList()));
            #endregion



            //CreateMap<ApplicationUser, RolsInUserDTO>();
            CreateMap<RolsInUserDTO, ApplicationUser>();
            #endregion

            #region Commands
            CreateMap<CreateTypeMeasurementUnitCommand, TypeMeasurementUnit>();
            #endregion
        }

    }
}
