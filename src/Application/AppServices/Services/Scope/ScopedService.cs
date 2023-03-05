using AppServices.IRepository;
using Contracts;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AppServices.Services.Scope
{
    public class ScopedService : IScopedService
    {
        public IScopeRepository _scopeRepository { get; set; }
        public ScopedService(IScopeRepository scopeRepository)
        {
            _scopeRepository = scopeRepository;
        }

        public async Task<InfoScopedResponse> AddScopeAsync(string text)
        {
            var newScoped = new Domain.Scope()
            {
                Text = text
            };

            await _scopeRepository.AddAsync(newScoped);

            return new InfoScopedResponse()
            {
                Id = newScoped.Id,
                Text = newScoped.Text,
                Actions = newScoped.Actions.Select(c => new InfoActionResponse()
                {
                    Id = c.Id,
                    Text = c.Text,
                    ScopeId = c.Id,
                }).ToList()
            };
        }

        public async Task DeleteScopedAsync(long id)
        {
            var scopeDel = await _scopeRepository.GetByIdAsync(id);
            if (scopeDel == null)
                throw new Exception("Сферы с таким идентификатором не существует");

            await _scopeRepository.DeleteAsync(scopeDel);
        }

        public async Task<InfoScopedResponse> EditScopedAsync(long id, string text)
        {
            var existingScope = await _scopeRepository.GetByIdAsync(id);
            if (existingScope == null)
                throw new Exception("Категории с таким идентификатором не сущесвует");

            existingScope.Text = text;
            await _scopeRepository.UpdateAsync(existingScope);

            return new InfoScopedResponse()
            {
                Id = existingScope.Id,
                Text = existingScope.Text,
                Actions = existingScope.Actions.Select(c => new InfoActionResponse()
                {
                    Id = c.Id,
                    Text = c.Text,
                    ScopeId = c.Id,
                }).ToList()
            };
        }

        public async Task<ICollection<InfoScopedResponse>> GetAllScopedAsync()
        {
            return await _scopeRepository.GetAll()
                .Select(a => new InfoScopedResponse()
                {
                    Id = a.Id,
                    Text = a.Text,
                    Actions = a.Actions.Select(c => new InfoActionResponse()
                    {
                        Id = c.Id,
                        Text = c.Text,
                        ScopeId = c.Id,
                    }).ToList()
                }).ToListAsync();
        }
    }
}
