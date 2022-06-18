﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class TypeMeasurementUnit : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
