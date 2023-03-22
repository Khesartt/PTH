using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTH.domain.models
{
    public class Role
    {
        public long id { get; set; }
        public string? name { get; set; }
        public bool active { get; set; }
    }
}
