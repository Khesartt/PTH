using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTH.services.DTO_s
{
    public class UserDTO
    {
        public long id { get; set; }
        public string? userLogin { get; set; }
        public string? password { get; set; }
        public string? email { get; set; }
        public long idRole { get; set; }
        public bool activo { get; set; }
        public Guid token { get; set; }
        public DateTime tokenDate { get; set; }

    }

    public class UserCreateDTO
    {
        public string? userLogin { get; set; }
        public string? password { get; set; }
        public string? email { get; set; }
        public long idRole { get; set; }
    }

    public class UserUpdateDTO
    {
        public long id { get; set; }
        public string? userLogin { get; set; }
        public string? password { get; set; }
        public string? email { get; set; }
        public bool activo { get; set; }
    }

}
