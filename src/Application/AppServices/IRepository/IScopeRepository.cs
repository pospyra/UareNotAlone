using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.IRepository
{
    public interface IScopeRepository
    {
        public IQueryable<Scope> GetAll();

        public Task<Scope> GetByIdAsync(long Id);

        public Task AddAsync(Scope model);

        public Task UpdateAsync(Scope model);

        public Task DeleteAsync(Scope model);
    }
}
