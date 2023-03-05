using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Scope
    {
        public long Id { get; set; }

        public string Text { get; set; }

        public ICollection<Action> Actions { get; set;}
    }
}
