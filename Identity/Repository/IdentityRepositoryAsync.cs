using Application.Interfaces;
using Ardalis.Specification.EntityFrameworkCore;
using Identity.Contexts;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Repository
{
    public class IdentityRepositoryAsync<T> : RepositoryBase<T>, IReadRepositoryAsync<T>
        where T : class
    {
        private readonly IdentityContext _identityContext;

        public IdentityRepositoryAsync(IdentityContext identityContext) : base(identityContext)
        {
            this._identityContext = identityContext;
        }

    }
}
