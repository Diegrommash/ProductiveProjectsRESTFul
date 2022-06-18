using Application.Parameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.TypeMeasurementUnits.Queries.GetAllMeasurementUnitQuery
{
    public class GetAllTypeMeasurementUnitParameters : RequestParameter
    {
        public string Name { get; set; }

    }
}
