using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTH.services.DTO_s
{
    public class UserDTO
    {
        public long Id { get; set; }
        public string? UserLogin { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public long IdRole { get; set; }
        public bool Activo { get; set; }
        public DateTime CreationDate { get; set; }
    }

    public class UserCreateDTO
    {
        public string? UserLogin { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public long IdRole { get; set; }
    }

    public class UserUpdateDTO
    {
        public long id { get; set; }
        public string? UserLogin { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public bool? Activo { get; set; }
    }

}
