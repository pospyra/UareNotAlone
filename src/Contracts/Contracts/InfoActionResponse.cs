using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class InfoActionResponse
    {
        public long Id { get; set; }

        public string Text { get; set; }

        public long ScopeId { get; set; }
    }
}
