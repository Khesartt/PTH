using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTH.domain.models
{
    public class Gender
    {
        public long id { get; set; }
        public string? name { get; set; }
        public bool active { get; set; }
        public string? Abbreviation { get; set; }
    }
}
