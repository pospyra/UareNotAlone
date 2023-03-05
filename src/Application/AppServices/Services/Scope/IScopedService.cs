using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Services.Scope
{
    public interface IScopedService
    {
        Task<ICollection<InfoScopedResponse>> GetAllScopedAsync();

        Task<InfoScopedResponse> AddScopeAsync(string text);

        Task DeleteScopedAsync(long id);

        Task<InfoScopedResponse> EditScopedAsync(long id, string text);
    }
}
