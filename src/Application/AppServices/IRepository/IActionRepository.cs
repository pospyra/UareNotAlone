using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.IRepository
{
    public interface IActionRepository
    {
        public IQueryable<Domain.Action> GetAll();

        public Task<Domain.Action> GetByIdAsync(int Id);

        public Task AddAsync(Domain.Action model);

        public Task UpdateAsync(Domain.Action model);

        public Task DeleteAsync(Domain.Action model);
    }
}
