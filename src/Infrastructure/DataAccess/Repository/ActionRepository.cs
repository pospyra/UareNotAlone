using AppServices.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ActionRepository : IActionRepository
    {
        protected DbContext DbContext { get; }
        protected DbSet<Domain.Action> DbSet { get; }

        public ActionRepository(DbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<Domain.Action>();
        }

        public async Task AddAsync(Domain.Action model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            await DbSet.AddAsync(model);
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Domain.Action model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            DbSet.Remove(model);
            await DbContext.SaveChangesAsync();
        }

        public IQueryable<Domain.Action> GetAll()
        {
            return DbSet;
        }

        public async Task<Domain.Action> GetByIdAsync(int Id)
        {
            return await DbSet.FindAsync(Id);
        }

        public async Task UpdateAsync(Domain.Action model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            DbSet.Update(model);
            await DbContext.SaveChangesAsync();
        }
    }
}
