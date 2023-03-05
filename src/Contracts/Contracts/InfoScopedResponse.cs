using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class InfoScopedResponse
    {
        public long Id { get; set; }

        public string Text { get; set; }

        public ICollection<InfoActionResponse> Actions { get; set; }
    }
}
