using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTH.domain.models
{
    public class Service
    {
        public long id { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public string? icono { get; set; }
    }
}
