using Application.Interfaces;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Repository
{
    public class ApplicationRepositoryAsync<T> : RepositoryBase<T>, IRepositoryAsync<T>
        where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        public ApplicationRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }
    }
}
