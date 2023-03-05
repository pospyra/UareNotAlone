using AppServices.IRepository;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ScopeRepository : IScopeRepository
    {
        protected DbContext DbContext { get; }
        protected DbSet<Scope> DbSet { get; }

        public ScopeRepository(DbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<Scope>();
        }

        public async Task AddAsync(Domain.Scope model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            await DbSet.AddAsync(model);
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Domain.Scope model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            DbSet.Remove(model);
            await DbContext.SaveChangesAsync();
        }

        public IQueryable<Domain.Scope> GetAll()
        {
            return DbSet;
        }

        public async Task<Domain.Scope> GetByIdAsync(long Id)
        {
            return await DbSet.FindAsync(Id);
        }

        public async Task UpdateAsync(Domain.Scope model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            DbSet.Update(model);
            await DbContext.SaveChangesAsync();
        }
    }
}
