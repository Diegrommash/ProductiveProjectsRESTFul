using Application.Parameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.RolsAndUsers.Queries.GetAllRolsInUserQuery
{
    public class GetAllRolsInUserQueryParameters : RequestParameter
    {
        public string Name { get; set; }
    }
}
