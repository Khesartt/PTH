using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTH.domain.models
{
    public class Parametric
    {
        public long id { get; set; }
        public string? key { get; set; }
        public string? value { get; set; }
        public string? description { get; set; }
    }
}
